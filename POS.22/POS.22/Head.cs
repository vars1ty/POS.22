using System.Diagnostics;
using CNLibrary;
using Memory;
using POS._22.low_level;
using static POS._22.Config;

namespace POS._22;

/// <summary>
/// Main logic.
/// </summary>
// * Made by narcotics.
internal static class Head
{
    #region Variables
    /// <summary>
    /// Instance to <see cref="Consult"/>.
    /// </summary>
    public static readonly Consult consult = new();

    /// <summary>
    /// Instance to <see cref="Mem"/>.
    /// </summary>
    public static readonly Mem mem = new();
    #endregion

    /// <summary>
    /// Initialize everything.
    /// </summary>
    public static async Task Run()
    {
        if (Process.GetProcessesByName(pxEngineRuntime) is {Length: 0})
        {
            Printer.WriteError($"Failed finding {pxEngineRuntime} - Make sure its open BEFORE running POS.22");
            return;
        }

        if (runMaxProcCheck)
            if (Process.GetProcessesByName(pxEngineRuntime) is {Length: > 1})
            {
                Printer.WriteError("Too many PXEngine Runtime instances are active!");
                return;
            }

        if (!consult.open_process(Process.GetProcessesByName(pxEngineRuntime)[0]))
        {
            Printer.WriteError(
                $"Failed opening {pxEngineRuntime} - Are you sure its open and that you are running POS.22 as an Administrator?");
            return;
        }

        if (!mem.OpenProcess(pxEngineRuntime))
        {
            Printer.WriteError(
                $"Failed opening {pxEngineRuntime} - Are you sure its open and that you are running POS.22 as an Administrator?");
            return;
        }

        Printer.WriteLine($"Hooked into {pxEngineRuntime} - Memory is open for R/W, moving to RYPatcher");
        await RYPatcher.DirectPatch();
    }
}