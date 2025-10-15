using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using HarmonyLib;
using Keen.Game2.Client.UI.Library;
using Keen.Game2.Client.UI.Menu;
using Keen.Game2.Client.UI.Menu.InGameMenu;
using Keen.Game2.Client.UI.Menu.MainMenu;
using Keen.VRage.UI.AvaloniaInterface;
using Keen.VRage.UI.Shared.Helpers;
using Pulsar.Modern.Screens.PluginsScreen;

namespace Pulsar.Modern.Patch;

[HarmonyPatch(typeof(GameMenu), "UpdateButtons")]
internal class GameMenu_UpdateButtons_Patch
{
    private static void Postfix(GameMenu __instance)
    {
        if (__instance._buttonsPanel == null)
        {
            return;
        }

        object dataContext = __instance.GetValue(GameMenu.DataContextProperty);

        SharedUIComponent? component = null;

        if (dataContext is MainMenuScreenViewModel mainMenuViewModel)
        {
            component = mainMenuViewModel._sharedUI;
        }
        else if (dataContext is InGameMenuScreenViewModel inGameMenuViewModel)
        {
            component = inGameMenuViewModel._sharedUI;
        }
        else
        {
            return;
        }

        Button pluginsButton = new()
        {
            Classes = { "Menu" },
            Content = "Plugins",
            Command = SimpleCommand.Create(delegate
            {
                component.CreateScreen<PluginsScreen>(new PluginsScreenViewModel(), true);
            })
        };

        __instance._buttonsPanel.Children.Insert(__instance._buttonsPanel.Children.Count - 2, pluginsButton);

#if DEBUG
        (AvaloniaApp.Instance.MainWindow as Window)?.AttachDevTools(new KeyGesture(Key.F12, KeyModifiers.Shift));
#endif
    }
}
