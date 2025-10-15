using Keen.VRage.UI.Screens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Modern.Screens.ProfilesScreen;

internal class ProfilesScreenViewModel : ScreenViewModel
{
    public ProfilesScreenViewModel(HashSet<string> enabledPlugins)
    {
        KeepsOtherScreensVisible = false;
        AllowsInputBelowUI = false;
        AllowsInputFromLowerScreens = false;
        InitializeInputContext();
    }
}
