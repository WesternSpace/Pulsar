using Keen.VRage.UI.Screens;
using System;

namespace Pulsar.Modern.Screens.TextInputDialog;
internal class TextInputDialogViewModel : ScreenViewModel
{
    public string Title { get; private set; }
    public string Text { get;  set; }
    public readonly Action<string> OnComplete;

    public TextInputDialogViewModel(string title,
    string defaultText = null,
    Action<string> onComplete = null)
    {
        KeepsOtherScreensVisible = false;
        AllowsInputBelowUI = false;
        AllowsInputFromLowerScreens = false;
        InitializeInputContext();
        Title = title;
        Text = defaultText;
        OnComplete = onComplete;
    }
}
