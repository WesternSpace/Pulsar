using HarmonyLib;
using Mono.Cecil;
using Mono.Cecil.Cil;
using Keen.VRage.Library.Diagnostics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using System.Text;
using System.Threading.Tasks;
using Pulsar.Shared;

namespace Pulsar.Modern.Launcher;

internal class GameLog : IGameLog
{
    public bool Exists()
    {
        string file = Log.Default?.FileName;
        return File.Exists(file) && file.EndsWith(".log");
    }

    public bool Open()
    {
        Log.Default.Flush();
        string file = Log.Default?.FileName;

        if (!File.Exists(file) || !file.EndsWith(".log"))
            return false;

        Process.Start(file);
        return true;
    }

    public void Write(string line) => Log.Default.WriteLine(line);
}

internal static class Game
{
    public static Version GetGameVersion(string game2Dir)
    {
        const string Assembly = "SpaceEngineers2.dll";

        var version = FileVersionInfo.GetVersionInfo(Path.Combine(game2Dir, Assembly));

        return new Version(version.FileVersion);
    }

    public static float GetLoadProgress()
    {
        // No native function in Space Engineers does this but we can estimate
        // FIXME: Does not work well with Preloaders or under Proton
        const float expectedGrowth = 1600f * 1024 * 1024;

        Process process = Process.GetCurrentProcess();
        process.Refresh();

        float ratio = process.PrivateMemorySize64 / expectedGrowth;

        return Math.Min(1f, Math.Max(0f, ratio));
    }

    public static void StartSpaceEngineers2(string[] args) 
    {
        AccessTools.TypeByName("Keen.Game2.Program").Method("Main").Invoke(null, [args]); 
    }

    public static void RunOnGameThread(Action action)
    {
        throw new NotImplementedException();
    }
}
