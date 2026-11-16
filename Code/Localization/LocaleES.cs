// <copyright file="LocaleES.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// This notice MUST be kept with copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocaleES.cs
// All 62 translation entries follow LocaleEN.cs order via LocaleTranslatedSource.

namespace UniqueBuildings
{
    public sealed class LocaleES : LocaleTranslatedSource
    {
        private static readonly string[] s_Text =
        {
            "Realistic Signature Buildings (Emblemas)", // 0
            "Acciones", // 1
            "Acerca de", // 2
            "Bonificaciones de edificios emblemáticos", // 3
            "Desbloqueo de edificios emblemáticos", // 4
            "Colocación", // 5
            "Estado", // 6
            "Información", // 7
            "Depuración / Registro", // 8
            "Bonificaciones globales de edificios emblemáticos", // 9
            "<Solo primera copia> **(predeterminado)** = un bono por tipo.\n<Sin bonos globales> = desactiva los bonos generales; el atractivo tiene su propia regla.\n<Acumulación original> = todas las copias cuentan.\n**El texto verde** del panel sigue visible incluso si el bono se bloquea.\nConsulta **Acciones > Estado** o **Acerca de > Informe al registro**.", // 10
            "Solo la primera copia", // 11
            "Sin bonificaciones globales", // 12
            "Acumulación normal", // 13
            "Atractivo de toda la ciudad", // 14
            "<Solo primera copia> **(predeterminado)** = un bono de atractivo por tipo.\n<Acumulación original> = todas las copias cuentan.\n<Sin bonus de atractivo> = desactiva el bono global.\n<Seguir ajuste global> = aplica la regla general.\n**El atractivo ayuda a atraer turistas.** El atractivo propio del edificio sigue activo.\n**El texto verde** no cambia.", // 15
            "Seguir ajuste global", // 16
            "Solo primera copia", // 17
            "Acumulación original", // 18
            "Sin bonus de atractivo", // 19
            "Efectos cercanos de edificios emblemáticos", // 20
            "<Efectos cercanos normales> = cada copia proporciona sus efectos cercanos habituales.\n<Solo la primera copia> = solo una copia de cada tipo proporciona efectos cercanos.\n<Sin efectos cercanos> = desactiva los efectos cercanos normales de los edificios emblemáticos.\nSe conservan los efectos de los edificios abandonados y el atractivo.", // 21
            "Efectos cercanos normales", // 22
            "Solo la primera copia", // 23
            "Sin efectos cercanos", // 24
            "Desbloquear todos los edificios emblemáticos", // 25
            "**ACTIVADO** = todos los edificios emblemáticos disponibles sin cumplir requisitos de población, zonificación o progreso.\n**DESACTIVADO** = progresión normal del juego.\nPor defecto: desactivado. Solo edificios emblemáticos, no otros edificios únicos.", // 26
            "Ocultar avisos de desbloqueo masivo de edificios emblemáticos", // 27
            "**ACTIVADO** (recomendado, predeterminado) = oculta los avisos del desbloqueo masivo realizado por este mod.\n**DESACTIVADO** = muestra un aviso por cada edificio emblemático que este mod desbloquee; pueden ser decenas o cientos.\nSiguen apareciendo los avisos normales del juego, incluidos edificios nuevos de actualizaciones, DLC, paquetes regionales y progreso de la ciudad.", // 28
            "Permitir varias copias", // 29
            "**ACTIVADO** = permite colocar varias copias de cualquier objeto marcado como único, incluidos los edificios emblemáticos.\n**DESACTIVADO** = una copia por ciudad, salvo que otro mod permita más.", // 30
            "Evitar vistas de información automáticas para edificios únicos", // 31
            "Evita que los edificios únicos, incluidos los emblemáticos, abran automáticamente el panel de información y la superposición de colores al colocarlos. Las vistas pueden abrirse manualmente. Las demás herramientas no cambian. Toggleable Overlays tiene prioridad si está activo. Predeterminado: ACTIVADO.", // 32
            "Regla de colocación de objetos únicos", // 33
            "**Copias permitidas** = se quitó el límite de un edificio por ciudad.\n**Uno de cada tipo** = límite normal activo.\n<Anarchy> también puede permitir copias.\nNo indica si los bonos se acumulan.", // 34
            "Edificios emblemáticos", // 35
            "**Colocados** = total de edificios emblemáticos.\n**Tipos** = modelos diferentes.\n<Copias extra> = edificios adicionales al primero de cada tipo.\nTambién cuenta edificios sin bonos globales.", // 36
            "Bonos generales de la ciudad", // 37
            "**Activos / Total** = proveedores incluidos por la regla global / todos los encontrados.\n<Bloqueados> = excluidos por esa regla, no el total de edificios extra.\n**El atractivo es independiente:** un proveedor bloqueado aún puede aportar atractivo.\nLos efectos cercanos son aparte.", // 38
            "Mods redundantes detectados", // 39
            "<Solo primera copia> = un bono de atractivo por tipo.\n<Acumulación original> = todas las copias.\n<Sin bonus> = desactivado.\n<Seguir ajuste global> = usar la regla general.\n**Muestra la regla elegida, no un total numérico.** Otras fuentes también aportan atractivo.\nEl texto verde permanece. Valores: **Acerca de > Informe al registro**.", // 40
            "No hay ninguna ciudad cargada", // 41
            "Cargando…", // 42
            "Carga una ciudad para ver el estado", // 43
            "Se permiten varias copias", // 44
            "Anarchy permite varias copias", // 45
            "Otro mod permite varios edificios únicos", // 46
            "Uno de cada tipo", // 47
            "Reglas mixtas", // 48
            "{0} colocados | {1} tipos | {2} copias extra", // 49
            "{0}/{1} activos | {2} bloqueados", // 50
            "Ninguno", // 51
            "Mod", // 52
            "Nombre que se muestra para este mod.", // 53
            "Versión", // 54
            "Versión instalada del mod y tipo de compilación.", // 55
            "Informe de estado al registro", // 56
            "Escribe en el registro los recuentos actuales de edificios emblemáticos, las bonificaciones globales y los efectos cercanos. No cambia ajustes ni efectos. Primero carga una ciudad.", // 57
            "Comparar modos de bonificación en el registro", // 58
            "Prueba temporalmente todos los modos de bonificación global y efectos cercanos mientras el juego está pausado en Opciones. Después vuelve a aplicar tus modos elegidos. Los resultados se guardan en el registro. Primero carga una ciudad.", // 59
            "Abrir registro", // 60
            "Abre el registro del mod o, si no está disponible, la carpeta de registros.", // 61
        };

        public LocaleES(UniqueBldgSettings setting)
            : base(setting)
        {
        }

        protected override string[] Text => s_Text;
    }
}
