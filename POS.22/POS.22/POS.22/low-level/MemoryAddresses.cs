namespace POS._22.low_level;

/// <summary>
/// Struct with pointers and offsets to the game.
/// </summary>
internal readonly struct MemoryAddresses
{
    // ! Warning: These offsets and addresses are only for 1 specific version, you can get your own by manually moving the CutsceneCamera position to something like 9592185 and scanning for it via Cheat Engine etc.
    /// <summary>
    /// Camera position pointer.
    /// </summary>
    private const string camPosPointer = "PXStudioRuntimeMMO.exe+0x005987C0,";

    /// <summary>
    /// Camera positions.
    /// </summary>
    public const string camPosX = camPosPointer + "0x2C,0x4,0x28,0xF0,0x70,0x34",
        camPosY = camPosPointer + "0x2C,0x4,0x28,0xF0,0x70,0x38",
        camPosZ = camPosPointer + "0x2C,0x4,0x28,0xF0,0x70,0x3C";
}