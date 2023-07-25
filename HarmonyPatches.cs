using HarmonyLib;
using MelonLoader;
using VRoid.Studio.EditRootScreen;
using VRoid.Studio.ModelPresetsSelector;

namespace VroidMassImporter
{
    [HarmonyPatch]
    class HarmonyPatches
    {
        [HarmonyPostfix]
        [HarmonyPatch(typeof(ViewModel), nameof(ViewModel.OnScreenActivate))]
        public static void OnScreenActivatePostfix(ViewModel __instance, ref CustomItemRegistry ____customItemRegistry)
        {
            MassImportMainModClass.GlobalBus = __instance.GlobalBus;
            Melon<MassImportMainModClass>.Logger.Msg("GlobalBus Set using method Patching.");

            MassImportMainModClass._customItemRegistry = ____customItemRegistry;
            Melon<MassImportMainModClass>.Logger.Msg("_customItemRegistry Set using method Patching.");
        }
    }
}
