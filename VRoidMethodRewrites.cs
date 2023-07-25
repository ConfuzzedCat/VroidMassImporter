using MelonLoader;
using System;
using VRoid.Studio;
using VRoid.Studio.ModelPresetsSelector;

namespace VroidMassImporter
{
    class VRoidMethodRewrites
    {
		public static async void ImportCustomItem(string[] files)
		{
            for (int i = 0; i < files.Length; i++)
            {
                Melon<MassImportMainModClass>.Logger.Msg("Importing file: {0}", files[i]);
                await MassImportMainModClass._customItemRegistry.ImportCustomItem(MassImportMainModClass.GlobalBus, files[i], new Action<GlobalBus, CustomItemErrorType>(CustomItemErrorDialogUtil.ImportError));
            }
            Melon<MassImportMainModClass>.Logger.Msg("All files imported.");

        }
	}
}
