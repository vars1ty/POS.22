using System.Diagnostics;
using Cysharp.Text;
using POS._22.low_level.scripting;
using static POS._22.Head;

namespace POS._22.low_level;

/// <summary>
/// Basic Star Stable Online patcher.
/// </summary>
// * Made by devin.
internal static class RYPatcher
{
    #region Variables
    /// <summary>
    /// AoB strings.
    /// </summary>
    private const string login_error =
            "67 6C 6F 62 61 6C 2F 4D 61 70 57 69 6E 64 6F 77 2E 53 74 61 72 74 28 29 3B",
        login_message =
            "67 6C 6F 62 61 6C 2F 4C 6F 67 69 6E 4D 65 6E 75 2E 53 74 61 72 74 28 29 3B";
    #endregion

    /// <summary>
    /// Try and patch the game.
    /// </summary>
    public static async Task DirectPatch()
    {
        Printer.WriteLine("RYPatcher: Starting, please wait...");
        var errorScan = (await mem.AoBScan(login_error, true)).ToList();
        if (errorScan is {Count: 0})
        {
            Printer.WriteError("RYPatcher: Found no values to patch, can't continue");
            Printer.WriteError("RYPatcher: Closing all PXEngine Runtime instances, please try again");
            var proc = Process.GetProcessesByName("PXStudioRuntimeMMO");
            var length = proc.Length;
            for (var i = 0; i < length; i++)
            {
                proc[i].Kill();
                Printer.WriteLine($"{proc[i].ProcessName} killed");
            }

            return;
        }

        var address = ZString.Concat("0x", errorScan[0].ToString("X"));
        WriteString(address, "global/IntroCam1.Stop();");
        Printer.WriteLine("RYPatcher: Skip authentication (LoginMenu)");
        Printer.WriteLine("RYPatcher: Value found, patching...");
        await PatchMessage();
        Printer.WriteLine("RYPatcher: Patched!");
    }

    /// <summary>
    /// Adds a small patch message.
    /// </summary>
    private static async Task PatchMessage()
    {
        var messageScan = (await mem.AoBScan(login_message, true)).ToList();
        var patch = new RYPXWrapper();
        // * Build a message.
        patch.WriteLine("~/GenericRequestWindow2/Headline.SetViewText(\"RYPatcher\");");
        patch.WriteLine(
            "~/GenericRequestWindow2/Message.SetViewText(\"RYPatcher Done\nPOS.22 Ready\");");
        patch.WriteLine("~/GenericRequestWindow2.Start();");
        patch.WriteLine("~/GameUI.Start();");
        patch.WriteLine("~/FadeDownLongWithText/View.SetViewText(\"Star Stable - 2018\");");
        patch.WriteLine("~/FadeDownLongWithText.Start();");
        patch.WriteLine($"~/PlayerName.SetDataString(\"{Config.pxPlayerName}\");");
        patch.WriteLine($"~/HorseName.SetDataString(\"{Config.pxHorseName}\");");
        WriteString(ZString.Concat("0x", messageScan[0].ToString("X")), ZString.Concat(patch.GetCode(), BuildWorld()));
    }

    /// <summary>
    /// Starts various systems.
    /// </summary>
    /// <returns></returns>
    private static string BuildWorld()
    {
        var builder = new RYPXWrapper();
        //builder.WriteLine("global/World/GameplaySystems.ActionStart();");
        builder.WriteLine("~/Introduction1.Start();");
        builder.WriteLine("~/LocationManager.Start();");
        builder.WriteLine("~/RecurringEventManager.Start();");
        builder.WriteLine("~/WorldClockSystem.Start();");
        builder.WriteLine("~/WorldCars.Start();");
        builder.WriteLine("~/QuestManager.Start();");
        builder.WriteLine("~/FadeUpToGame.Start();");
        builder.WriteLine("~/AchievementManager.Start();");
        builder.WriteLine("~/Achievements.Start();");
        builder.WriteLine("~/GameUI/HorseInfo.Start();");
        builder.WriteLine("~/Introduction1.Stop();");
        builder.WriteLine("~/IntroCam1.Stop();");
        // ? IntroCam1 isn't considered reliable enough to be used for SetPosition(), so we have to use a custom camera.
        // ? Hence why we are starting loads of objects above, so that we can access otherwise unloaded cameras.
        builder.WriteLine("~/CutSceneCamera.Start();");
        builder.WriteLine("~/CutSceneCamera.SetOrientationByObject(~/MoorlandStable);");
        builder.WriteLine("~/ChatWindow.RunScript(\"OnVillageChatEnable\");");
        builder.WriteLine("~/CutSceneCamera.SetPosition(0, 90, 20);");
        builder.WriteLine("~/CutSceneCamera.SetRotationY(0);");
        return builder.GetCode();
    }

    /// <summary>
    /// Write a string to the specified address.
    /// </summary>
    /// <param name="address"></param>
    /// <param name="content"></param>
    private static void WriteString(string address, string content) =>
        // ! "return;" was used in SSOUtils as well in order to prevent code behind it from running, decreasing the risk of crashing.
        consult.Memory.write_string(address, ZString.Concat(content, ");\nreturn;"));

    /// <summary>
    /// Write a string to the specified address.
    /// <para>This is the unsafe variant of <see cref="WriteString"/> because it doesn't add "return;" at the end or try to protect the input script code from crashes.</para>
    /// </summary>
    /// <param name="address"></param>
    /// <param name="content"></param>
    private static void WriteStringUnsafe(string address, string content) =>
        // ! "return;" was used in SSOUtils as well in order to prevent code behind it from running, decreasing the risk of crashing.
        consult.Memory.write_string(address, content);
}