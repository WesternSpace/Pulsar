using Keen.VRage.UI.Screens;
using System.Collections.Generic;

namespace Pulsar.Modern.Screens.PluginsScreen;

internal class PluginsScreenViewModel : ScreenViewModel
{

    //TODO
    public readonly HashSet<string> EnabledPlugins = null;

    public PluginsScreenViewModel() 
    {
        KeepsOtherScreensVisible = false;
        AllowsInputBelowUI = false;
        AllowsInputFromLowerScreens = false;
        InitializeInputContext();
    }

    // TODO
    public void Save()
    {

    }

    //TODO
    public bool RequiresRestart()
    {
        return true;
    }
}
