using MelonLoader;
using UnityEngine;
using VroidMassImporter;
using System.IO;
using System;
using System.Reflection;
using VRoid.Studio.ModelPresetsSelector;
using VRoid.Studio;

[assembly: MelonInfo(typeof(MassImportMainModClass), "VRoid Mass Importer", "0.0.1", "ConfuzzedCat")]

namespace VroidMassImporter
{
    class MassImportMainModClass : MelonMod
    {
        private bool showGUI = false;
        private string input = "Write path here.";
        private Rect windowRect = new Rect(10, 10, 300, 120);
        internal static CustomItemRegistry _customItemRegistry;
        internal static GlobalBus GlobalBus;

        public override void OnInitializeMelon()
        {
            LoggerInstance.Msg("MassImporter Initialized.");
        }

        public override void OnUpdate()
        {
            if (Input.GetKeyDown(KeyCode.F1))
            {
                if(_customItemRegistry != null && GlobalBus != null)
                {
                    showGUI = !showGUI;
                    return;
                }
                LoggerInstance.Warning("ShowGUI key pressed, but patched method hasn't been run yet.");
            }
        }
        public override void OnGUI()
        {
            if (showGUI)
            {
                windowRect = GUI.Window(0, windowRect, DrawMenu, "MassImport Gui");
            }
        }

        private void DrawMenu(int windowID)
        {
            GUI.DragWindow(new Rect(0, 0, 10000, 20));

            input = GUI.TextField(new Rect(150 - 100, 30, 200, 20), input);
            if (GUI.Button(new Rect(150 - 125, 60, 250, 30), "Select folder to import from"))
            {
                if (!Directory.Exists(input))
                {
                    LoggerInstance.Error("The given path doesn't exist. Path: {0}", input);
                    return;
                }


                string[] files = Directory.GetFiles(input, "*.vroidcustomitem");
                if(files.Length > 0)
                {
                    VRoidMethodRewrites.ImportCustomItem(files);
                    return;
                }
                LoggerInstance.Error("Directory didn't contain any vroidcustomitem files: {0}", input);
            }
        }
    }
}
