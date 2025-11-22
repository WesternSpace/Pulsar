using HarmonyLib;
using Keen.Game2.Client.UI.Menu;
using Keen.Game2.Game.Plugins;
using Pulsar.Modern.Loader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Modern.Patch;

[HarmonyPatchCategory("Early")]
[HarmonyPatch(typeof(PluginHost), MethodType.Constructor, [typeof(string[])])]
internal class PluginHost_ctor_Patch
{
    private static void Postfix(PluginHost __instance)
    {
        __instance.Add(typeof(PluginLoader));
    }
}
