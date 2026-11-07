// <copyright file="LocaleES.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// This notice MUST be kept with copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocaleES.cs
// All 41 translation entries follow LocaleEN.cs order via LocaleTranslatedSource.

namespace UniqueBuildings
{
    public sealed class LocaleES : LocaleTranslatedSource
    {
        private static readonly string[] s_Text =
        {
            "Realistic Signature Buildings (Edificios emblemáticos realistas)", // 0
            "Acciones", // 1
            "Acerca de", // 2
            "Bonificaciones de edificios emblemáticos", // 3
            "Desbloqueo de edificios emblemáticos", // 4
            "Varios edificios únicos", // 5
            "Estado", // 6
            "Información", // 7
            "Depuración / Registro", // 8
            "Bonificaciones globales de edificios emblemáticos", // 9
            "<Solo la primera copia> = cada tipo de edificio emblemático aporta su bonificación global una vez.\n<Sin bonificaciones globales> = desactiva las bonificaciones globales de los edificios emblemáticos.\n<Acumulación normal> = cada copia aporta su bonificación global.\nLos efectos cercanos tienen otro ajuste. El atractivo del edificio no cambia.", // 10
            "Solo la primera copia", // 11
            "Sin bonificaciones globales", // 12
            "Acumulación normal", // 13
            "Efectos cercanos de edificios emblemáticos", // 14
            "<Efectos cercanos normales> = cada copia proporciona sus efectos cercanos habituales.\n<Solo la primera copia> = solo una copia de cada tipo proporciona efectos cercanos.\n<Sin efectos cercanos> = desactiva los efectos cercanos normales de los edificios emblemáticos.\nSe conservan los efectos de los edificios abandonados y el atractivo.", // 15
            "Efectos cercanos normales", // 16
            "Solo la primera copia", // 17
            "Sin efectos cercanos", // 18
            "Desbloquear requisitos de edificios emblemáticos", // 19
            "**ACTIVADO** = todos los edificios emblemáticos disponibles sin cumplir requisitos de población, zonificación o progreso.\n**DESACTIVADO** = progresión normal del juego.", // 20
            "Permitir varias copias", // 21
            "**ACTIVADO** = permite colocar varias copias de cualquier objeto marcado como único, incluidos los edificios emblemáticos.\n**DESACTIVADO** = una copia por ciudad, salvo que otro mod permita más.", // 22
            "Regla de colocación de objetos únicos", // 23
            "Indica si actualmente se pueden colocar varias copias de objetos únicos.", // 24
            "Edificios emblemáticos", // 25
            "Muestra los edificios emblemáticos colocados, los tipos distintos y las copias adicionales.", // 26
            "Bonificaciones globales", // 27
            "Cuenta los edificios emblemáticos que aportan bonificaciones globales.\nNo incluye los efectos locales o cercanos.", // 28
            "Informe de bonificaciones al registro", // 29
            "Prueba los tres modos de bonificaciones globales, escribe los valores reales de la ciudad en el registro y restaura el modo elegido. No necesitas comparar manualmente.", // 30
            "Informe de efectos cercanos al registro", // 31
            "Comprueba los tres modos de efectos cercanos en el registro y restaura el modo elegido.", // 32
            "Mods redundantes detectados", // 33
            "Anarchy es compatible y no aparece aquí.\nElimina otros mods de edificios únicos ilimitados: este mod ya incluye esa función.", // 34
            "Mod", // 35
            "Nombre que se muestra para este mod.", // 36
            "Versión", // 37
            "Versión instalada del mod y tipo de compilación.", // 38
            "Abrir registro", // 39
            "Abre el registro del mod o, si no está disponible, la carpeta de registros.", // 40
        };

        public LocaleES(UniqueBldgSettings setting)
            : base(setting)
        {
        }

        protected override string[] Text => s_Text;
    }
}
