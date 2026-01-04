using Avalonia.Controls;
using Keen.VRage.UI.AvaloniaInterface.Services;

namespace Pulsar.Modern.Screens.AddPluginScreen;

[NeedsWindowStyles]
public partial class AddPluginScreen : PluginScreenBase
{
    public AddPluginScreen()
    {
        InitializeComponent();

        if (!Design.IsDesignMode)
        {
            if ((DataContext as AddPluginScreenViewModel).Mods)
                TitleText.Text = "Mod List";
        }
    }

    private void SearchBox_TextChanged(object? sender, TextChangedEventArgs e)
    {
        if (SearchBox.Text != string.Empty)
            SearchClearButton.IsVisible = true;
        else
            SearchClearButton.IsVisible = false;
    }

    private void SearchClearButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        SearchBox.Text = string.Empty;
    }
}