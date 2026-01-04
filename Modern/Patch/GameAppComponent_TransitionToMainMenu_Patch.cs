using HarmonyLib;
using Keen.Game2;
using Pulsar.Shared.Splash;

namespace Pulsar.Modern.Patch;

[HarmonyPatchCategory("Early")]
[HarmonyPatch(typeof(GameAppComponent), "TransitionToMainMenu")]
internal static class GameAppComponent_TransitionToMainMenu_Patch
{
    public static void Postfix()
    {
        SplashManager.Instance?.Delete();
    }
}