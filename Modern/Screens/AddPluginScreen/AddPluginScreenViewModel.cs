using Keen.VRage.UI.Screens;
using System;

namespace Pulsar.Modern.Screens.AddPluginScreen
{
    internal class AddPluginScreenViewModel : ScreenViewModel
    {
        public event Action OnScreenClose;
        public readonly bool Mods;

        public AddPluginScreenViewModel(bool mods)
        {
            KeepsOtherScreensVisible = false;
            AllowsInputBelowUI = false;
            AllowsInputFromLowerScreens = false;
            InitializeInputContext();

            Mods = mods;
        }
    }
}
