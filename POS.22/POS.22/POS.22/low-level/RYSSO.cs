namespace POS._22.low_level;

/// <summary>
/// Basic Star Stable Online memory writing utility.
/// </summary>
// * Made by devin.
internal static class RYSSO
{
    #region Variables
    /// <summary>
    /// Address to the minimap.
    /// </summary>
    public static string mapAddress;
    #endregion

    /// <summary>
    /// Modify the PXScript of the Minimap.
    /// </summary>
    /// <param name="pxScript"></param>
    public static void SetMap(string pxScript) => Head.consult.Memory.write_string(mapAddress, pxScript);
}