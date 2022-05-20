using Newtonsoft.Json.Linq;

namespace POS._22;

/// <summary>
/// Basic access to config.jsom
/// </summary>
// * Made by devin.
internal static class Config
{
    #region Variables
    #region Return
    public static string pxEngineRuntime = null!;
    public static string pxPlayerName = null!;
    public static string pxHorseName = null!;
    public static bool printerActive = true;
    public static bool runMaxProcCheck;
    #endregion

    /// <summary>
    /// The file name.
    /// </summary>
    private const string file = "config.json";
    #endregion

    /// <summary>
    /// Fetches the config and updates everything in the cache.
    /// </summary>
    public static void FetchConfig()
    {
        if (!File.Exists(file)) Environment.Exit(-1);
        var parsed = JObject.Parse(File.ReadAllText(file));
        pxEngineRuntime = parsed["PXENGINE_RUNTIME_PROCESS"]?.ToString() ?? "PXStudioRuntimeMMO";
        runMaxProcCheck = Convert.ToBoolean(parsed["RUN_MAX_PROCESS_COUNT_CHECK"]);
        printerActive = Convert.ToBoolean(parsed["PRINTER_ACTIVE"]);
        const string defaultName = "Project Old SSO";
        pxPlayerName = parsed["PX_PLAYER_NAME"]?.ToString() ?? defaultName;
        pxHorseName = parsed["PX_HORSE_NAME"]?.ToString() ?? defaultName;
    }
}