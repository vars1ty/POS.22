namespace POS._22.low_level.scripting;

/// <summary>
/// Util to make working with in-game scripting easier.
/// </summary>
// * Made by narcotics.
internal struct RYPXWrapper
{
    #region Variables
    /// <summary>
    /// The script code.
    /// </summary>
    private static string rawCode = null!;
    #endregion

    /// <summary>
    /// Write a line of script.
    /// </summary>
    /// <param name="code"></param>
    /// <param name="endWithNewLine">Note: This may cause crashes!</param>
    public void WriteLine(string code, bool endWithNewLine = false) => rawCode += endWithNewLine ? $"{code}\n" : code;

    /// <summary>
    /// Returns the script code.
    /// </summary>
    /// <returns></returns>
    public string GetCode() => RYPX.GetPixelScript(rawCode);
}