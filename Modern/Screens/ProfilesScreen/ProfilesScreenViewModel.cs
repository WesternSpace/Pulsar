using Keen.VRage.UI.Screens;
using Pulsar.Shared.Data;

namespace Pulsar.Modern.Screens.ProfilesScreen;

internal class ProfilesScreenViewModel : ScreenViewModel
{
    public ProfilesScreenViewModel(Profile draft)
    {
        KeepsOtherScreensVisible = false;
        AllowsInputBelowUI = false;
        AllowsInputFromLowerScreens = false;
        InitializeInputContext();
    }
}
