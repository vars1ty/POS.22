namespace POS._22.low_level.scripting;

/// <summary>
/// Short-hand wrapper around PXScript, aimed to make functions and such easier to understand.
/// </summary>
// * Made by narcotics.
internal static class RYPX
{
    #region Variables
    /// <summary>
    /// Code Set.
    /// </summary>
    private static readonly Dictionary<string, string> wrap = new();
    #endregion

    /// <summary>
    /// Builds the entire code set.
    /// </summary>
    public static void BuildCodeSet()
    {
        Printer.WriteLine("RYPX: Building code set...");
        wrap.Add("~/", "global/");
        wrap.Add("MoveTo", "SetOrientationByObject");
        wrap.Add("SetInvisible!(1)", "SetScale(0,0,0)");
        wrap.Add("SetInvisible!(0)", "SetScale(1,1,1)");
        wrap.Add("ret;", "return;");
        Printer.WriteLine("RYPX: Code set built!");
    }

    /// <summary>
    /// Converts RYPX -> PXScript
    /// </summary>
    /// <param name="rypx"></param>
    /// <returns></returns>
    public static string GetPixelScript(string rypx)
    {
        var result = rypx;
        foreach (var set in wrap) result = result.Replace(set.Key, set.Value);
        return result;
    }
}