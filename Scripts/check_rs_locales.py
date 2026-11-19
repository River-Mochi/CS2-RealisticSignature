# <copyright file="check_rs_locales.py" company="River-Mochi">
# Copyright (c) 2026 River-Mochi. All rights reserved.
# Licensed under the GNU General Public License v3.0 or later,
# with the Cities: Skylines II Linking Exception.
# See LICENSE and LICENSE-EXCEPTION in the project root.
# ================= </copyright> ======================
#
# Checks the 64-entry array localization used by Realistic Signature.
# Run from the repository root: py Scripts/check_rs_locales.py

from __future__ import annotations

import json
import re
import sys
from collections import Counter
from pathlib import Path

from check_locales import (
    dictionary_body,
    dictionary_entries,
    literal_text,
    marker_issues,
    normalize_key,
    placeholders,
    split_entry,
)

ROOT = Path(__file__).resolve().parents[1]
LOCALES = ROOT / "Code" / "Localization"
ENTRY = re.compile(r'^\s*("(?:\\.|[^"\\])*"),\s*//\s*(\d+)\s*$')
INDEX = re.compile(r'^t\[(\d+)\]$')
HIGHLIGHT = re.compile(r'<([^<>\n]+)>')
NUM_ENTRIES = 64


def normalize_source_key(expression: str) -> str:
    key = normalize_key(expression)
    return key[len("LocaleEN."):] if key.startswith("LocaleEN.") else key


def load_dictionary(path: Path) -> list[tuple[str, str]]:
    text = path.read_text(encoding="utf-8-sig")
    result = []
    for entry in dictionary_entries(dictionary_body(text)):
        key, value = split_entry(entry)
        result.append((normalize_source_key(key), value.strip()))
    return result


def load_array(path: Path) -> list[str]:
    rows: list[tuple[int, str]] = []
    for line in path.read_text(encoding="utf-8-sig").splitlines():
        match = ENTRY.fullmatch(line)
        if match:
            rows.append((int(match.group(2)), json.loads(match.group(1))))

    indexes = [i for i, _ in rows]
    if indexes != list(range(NUM_ENTRIES)):
        raise ValueError(
            f"expected numbered entries 0-{NUM_ENTRIES - 1} in order; "
            f"found {len(indexes)} entries with indexes {indexes}"
        )
    return [value for _, value in rows]


def check() -> int:
    en_path = LOCALES / "LocaleEN.cs"
    mapper_path = LOCALES / "LocaleTranslatedSource.cs"
    english = load_dictionary(en_path)
    mapped = load_dictionary(mapper_path)

    errors: list[str] = []
    english_keys = [key for key, _ in english]
    mapped_keys = [key for key, _ in mapped]
    if english_keys != mapped_keys:
        missing = sorted(set(english_keys) - set(mapped_keys))
        extra = sorted(set(mapped_keys) - set(english_keys))
        errors.append(
            f"LocaleTranslatedSource key order differs from English; "
            f"missing={missing}, extra={extra}"
        )
    if len(english_keys) != len(set(english_keys)):
        errors.append("LocaleEN has duplicate localization keys")
    if len(mapped_keys) != len(set(mapped_keys)):
        errors.append("LocaleTranslatedSource has duplicate localization keys")

    mapper_indexes: list[int] = []
    for key, expression in mapped:
        match = INDEX.fullmatch(expression)
        if not match:
            errors.append(f"Mapper key {key} does not refer to a numbered t[index]")
            continue
        mapper_indexes.append(int(match.group(1)))
    if set(mapper_indexes) != set(range(NUM_ENTRIES)):
        errors.append("The mapper does not use all 64 translation entries")

    english_by_key = {key: literal_text(value) for key, value in english}
    languages = sorted(
        path for path in LOCALES.glob("Locale*.cs")
        if path.name not in ("LocaleEN.cs", "LocaleTranslatedSource.cs")
    )

    for path in languages:
        try:
            translations = load_array(path)
        except (ValueError, json.JSONDecodeError) as error:
            errors.append(f"{path.name}: {error}")
            continue

        for index, value in enumerate(translations):
            if not value.strip():
                errors.append(f"{path.name}: empty translation #{index}")
            for warning in marker_issues(value):
                errors.append(f"{path.name} #{index}: {warning}")

        # Green-highlighted dropdown names must match the locale's actual
        # visible choices, not an older translation or literal English.
        for tooltip, choices in (
            (10, (11, 12, 13)),
            (15, (17, 18, 19, 16)),
            (21, (22, 23, 24)),
        ):
            actual = HIGHLIGHT.findall(translations[tooltip])
            expected = [translations[i] for i in choices]
            if actual != expected:
                errors.append(
                    f"{path.name} #{tooltip}: green option names don't match "
                    f"dropdown choices: {actual!r} vs {expected!r}"
                )

        for (key, _), index in zip(mapped, mapper_indexes):
            en_value = english_by_key.get(key, "")
            translated = translations[index]
            if en_value and placeholders(en_value) != placeholders(translated):
                errors.append(
                    f"{path.name} #{index} ({key}): placeholders differ "
                    f"from English"
                )

        # These three statuses must not accidentally reuse bonus mode text.
        if "<Anarchy>" not in translations[40]:
            errors.append(
                f"{path.name} #40: redundant-mod tooltip must mention Anarchy"
            )
        if translations[46] == translations[48]:
            errors.append(
                f"{path.name}: 'Unlimited copies still active' and "
                "'Mixed rules' need different translations"
            )

        print(f"{path.name}: {NUM_ENTRIES} entries checked")

    if len(languages) != 14:
        errors.append(f"Expected 14 translated languages, found {len(languages)}")

    if errors:
        print("\nLocale check FAILED:")
        for error in errors:
            print("  - " + error)
        return 1

    print(
        f"All locale checks GOOD. {len(languages)} languages, "
        f"{NUM_ENTRIES} entries each, {len(english)} localization keys."
    )
    return 0


if __name__ == "__main__":
    try:
        sys.exit(check())
    except (FileNotFoundError, ValueError) as error:
        print(f"Locale check FAILED: {error}", file=sys.stderr)
        sys.exit(1)
