using System.Runtime.InteropServices;

namespace POS._22.low_level.key;

/// <summary>
/// Keyboard utility.
/// </summary>
// * Made by narcotics.
internal static class NativeKeyboard
{
    #region WinAPI
    /// <summary>
    /// Get the key state of a virtual key.
    /// </summary>
    /// <param name="nVirtKey"></param>
    /// <returns></returns>
    [DllImport("USER32.dll")]
    private static extern short GetKeyState(NativeInput nVirtKey);
    #endregion

    /// <summary>
    /// Check whether or not a virtual key is being pressed.
    /// <para>VKey List: https://docs.microsoft.com/en-us/windows/win32/inputdev/virtual-key-codes</para>
    /// </summary>
    /// <param name="vKey"></param>
    /// <returns></returns>
    public static bool IsKeyPressed(NativeInput vKey) =>
        Convert.ToBoolean(GetKeyState(vKey) & 0x8000); // 0x8000 = Key Pressed
}