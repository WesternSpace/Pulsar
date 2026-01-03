using Keen.Game2.Client.UI.Library.Dialogs.OneOptionDialog;
using Keen.VRage.UI.Screens;
using Pulsar.Shared;
using Pulsar.Shared.Config;
using Pulsar.Shared.Data;
using System;

namespace Pulsar.Modern.Screens.ProfilesScreen;

internal class ProfilesScreenViewModel : ScreenViewModel
{
    public event Action<Profile> OnDraftChange;

    public event Action OnScreenClose;

    public readonly ProfilesConfig Config = ConfigManager.Instance.Profiles;

    public readonly Profile Draft;

    public ProfilesScreenViewModel(Profile draft)
    {
        KeepsOtherScreensVisible = false;
        AllowsInputBelowUI = false;
        AllowsInputFromLowerScreens = false;
        InitializeInputContext();
        this.Draft = draft;
    }

    public void LoadProfile(Profile p)
    {
        Profile newDraft = Tools.DeepCopy(p);
        OnDraftChange(newDraft);
    }

    public Profile CreateProfile(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            return null;

        Profile newProfile = Tools.DeepCopy(Draft);
        newProfile.Name = name;

        if (Config.Exists(newProfile.Key))
        {
            ShowDuplicateWarning(name);
            return null;
        }

        Config.Add(newProfile);
        return newProfile;
    }

    public void ShowDuplicateWarning(string name)
    {
        var definition = ScreenTools.GetDefaultOkDialog();
        definition.Title = ScreenTools.GetKeyFromString("Duplicate Profile");
        definition.Content = ScreenTools.GetKeyFromString($"A profile called {name} already exists!\n" + "Please enter a different name.");

        ScreenTools.GetSharedUIComponent().ShowDialog(new OneOptionDialogViewModel(definition));
    }

    public override void OnClose()
    {
        base.OnClose();
        OnScreenClose?.Invoke();
    }
}
