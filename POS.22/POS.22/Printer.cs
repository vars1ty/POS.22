using System.Drawing;
using POS._22.low_level.key.game;
using Console = Colorful.Console;

namespace POS._22;

/// <summary>
/// Basic Console writing utils.
/// </summary>
// * Made by narcotics.
internal readonly struct Printer
{
    /// <summary>
    /// Write a basic message.
    /// </summary>
    /// <param name="content"></param>
    public static void WriteLine(string content)
    {
        if (!Config.printerActive) return;
        Console.Write("[ ", Color.White);
        Console.Write("SYS", Color.GreenYellow);
        Console.Write(" ] ", Color.White);
        Console.WriteLine(content, Color.White);
    }

    /// <summary>
    /// Write a basic info message.
    /// </summary>
    /// <param name="content"></param>
    public static void WriteInfo(string content)
    {
        if (!Config.printerActive) return;
        Console.Write("[ ", Color.White);
        Console.Write("INFO", Color.White);
        Console.Write(" ] ", Color.White);
        Console.WriteLine(content, Color.White);
    }

    /// <summary>
    /// Write a basic warning message.
    /// </summary>
    /// <param name="content"></param>
    public static void WriteWarning(string content)
    {
        if (!Config.printerActive) return;
        Console.Write("[ ", Color.White);
        Console.Write("WARN", Color.OrangeRed);
        Console.Write(" ] ", Color.White);
        Console.WriteLine(content, Color.White);
    }

    /// <summary>
    /// Write a basic error message.
    /// </summary>
    /// <param name="content"></param>
    public static void WriteError(string content)
    {
        RYFreeCam.Destroy();
        if (!Config.printerActive) return;
        Console.Write("[ ", Color.White);
        Console.Write("ERROR", Color.Red);
        Console.Write(" ] ", Color.White);
        Console.WriteLine(content, Color.White);
    }

    /// <summary>
    /// Writes a basic tutorial.
    /// </summary>
    public static void WriteTutorial()
    {
        if (!Config.printerActive) return;
        WriteInfo("--------------------------------------------------------------------");
        WriteInfo("Welcome to Project Old SSO!");
        WriteInfo("Discord Server: https://discord.gg/QQTfpAprS9");
        WriteInfo("Here's a quick cheat-sheet of the keybindings available for you:");
        WriteInfo("[W-A-S-D] = Moves you forwards, backwards and to the sides");
        WriteInfo("[SHIFT]   = Moves you downwards");
        WriteInfo("[SPACE]   = Moves you upwards");
        WriteInfo("[PLUS]    = Increases your movement speed");
        WriteInfo("[MINUS]   = Decreases your movement speed");
        WriteInfo("Have fun exploring the old Star Stable Online, the one without Clara Lightland!");
        WriteInfo("--------------------------------------------------------------------");
        WriteWarning("This is a beta version, therefore bugs may occur!");
    }
}