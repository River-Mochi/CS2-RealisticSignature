// <copyright file="LocaleES.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// This notice MUST be kept with copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocaleES.cs
// All 45 translation entries follow LocaleEN.cs order via LocaleTranslatedSource.

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
            "Colocación", // 5
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
            "Ocultar avisos de desbloqueo masivo de edificios emblemáticos", // 21
            "**ACTIVADO** (recomendado, predeterminado) = oculta los avisos del desbloqueo masivo realizado por este mod.\n**DESACTIVADO** = muestra un aviso por cada edificio emblemático que este mod desbloquee; pueden ser decenas o cientos.\nSiguen apareciendo los avisos normales del juego, incluidos edificios nuevos de actualizaciones, DLC, paquetes regionales y progreso de la ciudad.", // 22
            "Permitir varias copias", // 23
            "**ACTIVADO** = permite colocar varias copias de cualquier objeto marcado como único, incluidos los edificios emblemáticos.\n**DESACTIVADO** = una copia por ciudad, salvo que otro mod permita más.", // 24
            "Evitar vistas de información automáticas para edificios únicos", // 25
            "Evita que los edificios únicos, incluidos los emblemáticos, abran automáticamente el panel de información y la superposición de colores al colocarlos. Las vistas pueden abrirse manualmente. Las demás herramientas no cambian. Toggleable Overlays tiene prioridad si está activo. Predeterminado: ACTIVADO.", // 26
            "Regla de colocación de objetos únicos", // 27
            "Indica si actualmente se pueden colocar varias copias de objetos únicos.", // 28
            "Edificios emblemáticos", // 29
            "Muestra los edificios emblemáticos colocados, los tipos distintos y las copias adicionales.", // 30
            "Bonificaciones globales", // 31
            "Cuenta los edificios emblemáticos que aportan bonificaciones globales.\nNo incluye los efectos locales o cercanos.", // 32
            "Mods redundantes detectados", // 33
            "Anarchy es compatible y no aparece aquí.\nElimina otros mods de edificios únicos ilimitados: este mod ya incluye esa función.", // 34
            "Mod", // 35
            "Nombre que se muestra para este mod.", // 36
            "Versión", // 37
            "Versión instalada del mod y tipo de compilación.", // 38
            "Informe de estado al registro", // 39
            "Escribe en el registro los recuentos actuales de edificios emblemáticos, las bonificaciones globales y los efectos cercanos. No cambia ajustes ni efectos. Primero carga una ciudad.", // 40
            "Comparar modos de bonificación en el registro", // 41
            "Prueba temporalmente todos los modos de bonificación global y efectos cercanos mientras el juego está pausado en Opciones. Después vuelve a aplicar tus modos elegidos. Los resultados se guardan en el registro. Primero carga una ciudad.", // 42
            "Abrir registro", // 43
            "Abre el registro del mod o, si no está disponible, la carpeta de registros.", // 44
            "No hay ninguna ciudad cargada", // 45
            "Cargando…", // 46
            "Carga una ciudad para ver el estado", // 47
            "Se permiten varias copias", // 48
            "Anarchy permite varias copias", // 49
            "Otro mod permite varios edificios únicos", // 50
            "Uno de cada tipo", // 51
            "Reglas mixtas", // 52
            "{0} colocados | {1} tipos | {2} copias extra", // 53
            "{0} proveedores activos | {1} proveedores duplicados", // 54
            "Ninguno", // 55
        };

        public LocaleES(UniqueBldgSettings setting)
            : base(setting)
        {
        }

        protected override string[] Text => s_Text;
    }
}
