using Avalonia.Interactivity;
using Keen.Game2;
using Keen.Game2.Client.UI.Library.Dialogs.ThreeOptionsDialog;
using Keen.VRage.Core;
using Keen.VRage.Library.Utils;
using Keen.VRage.UI.AvaloniaInterface.Services;
using Keen.VRage.UI.Screens;
using Pulsar.Modern.Screens.ProfilesScreen;

namespace Pulsar.Modern.Screens.PluginsScreen;

[NeedsWindowStyles]
public partial class PluginsScreen : ScreenView
{
    public PluginsScreen()
    {
        InitializeComponent();
    }

    private void CancelButton_OnClick(object? sender, RoutedEventArgs e)
    {
        Dispose();
    }

    private void ApplyButton_OnClick(object? sender, RoutedEventArgs e)
    {
        if ((DataContext as PluginsScreenViewModel).RequiresRestart())
        {
            var definition = ScreenTools.GetDefaultYesNoCancelDialog();
            definition.Title = ScreenTools.GetKeyFromString("Apply Changes?");
            definition.Content = ScreenTools.GetKeyFromString("A restart is required to apply changes. Would you like to restart the game now?");

            Singleton<VRageCore>.Instance.Engine.Get<GameAppComponent>().MainMenu._sharedUI.ShowDialog(new ThreeOptionsDialogViewModel(definition)
            {
                ConfirmAction = () =>
                {
                    (DataContext as PluginsScreenViewModel).Save();
                    //LoaderTools.AskToRestart();
                },
                DefaultAction = () => 
                {
                    (DataContext as PluginsScreenViewModel).Save();
                    Dispose();
                }
            });
        }
        else
        {
            Dispose();
        }
    }

    private void ProfilesButton_OnClick(object? sender, RoutedEventArgs e)
    {
        Singleton<VRageCore>.Instance.Engine.Get<GameAppComponent>().MainMenu._sharedUI.CreateScreen<ProfilesScreen.ProfilesScreen>(new ProfilesScreenViewModel((DataContext as PluginsScreenViewModel).EnabledPlugins));
    }
}