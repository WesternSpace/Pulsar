using HarmonyLib;
using Pulsar.Shared.Splash;

namespace Pulsar.Modern.Patch;

[HarmonyPatchCategory("Early")]
[HarmonyPatch("Keen.VRage.Platform.Windows.Forms.GameWindow, VRage.Platform.Windows", "ShowAndFocus")]
internal static class GameWindow_ShowAndFocus_Patch
{
    public static void Prefix()
    {
        SplashManager.Instance?.Delete();
    }
}