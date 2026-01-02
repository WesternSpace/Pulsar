using Avalonia.Controls;
using Avalonia.Interactivity;
using Keen.VRage.UI.Screens;
using Pulsar.Shared;
using Pulsar.Shared.Config;
using Pulsar.Shared.Data;
using System.Collections.Generic;

namespace Pulsar.Modern.Screens.PluginsScreen;

internal class PluginsScreenViewModel : ScreenViewModel
{
    public Profile Draft { get; private set; }

    public readonly PluginList PluginList;
    public readonly List<PluginData> EnabledPluginList;
    private readonly ProfilesConfig profiles;
    private readonly SourcesConfig sources;

    public bool ConsentGiven = PlayerConsent.ConsentGiven;

    public PluginsScreenViewModel(ConfigManager configManager)
    {
        KeepsOtherScreensVisible = false;
        AllowsInputBelowUI = false;
        AllowsInputFromLowerScreens = false;

        Draft = Tools.DeepCopy(configManager.Profiles.Current);
        PluginList = configManager.List;
        profiles = configManager.Profiles;
        sources = configManager.Sources;

        InitializeInputContext();
    }

    public static void Open()
    {
        var configManager = ConfigManager.Instance;
        PluginsScreenViewModel menu = new(configManager);
        configManager.List.UpdateRemoteList();
        configManager.List.UpdateLocalList();
        ScreenTools.GetSharedUIComponent().CreateScreen<PluginsScreen>(menu);
    }

    public void OnConsentBoxChanged(object sender, RoutedEventArgs e)
    {
        PlayerConsent.ShowDialog();
        UpdateConsentBox((CheckBox)sender);
    }

    public void UpdateConsentBox(CheckBox checkbox)
    {
        if (checkbox.IsChecked != PlayerConsent.ConsentGiven)
        {
            checkbox.IsCheckedChanged -= OnConsentBoxChanged;
            checkbox.IsChecked = PlayerConsent.ConsentGiven;
            checkbox.IsCheckedChanged += OnConsentBoxChanged;
        }
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
