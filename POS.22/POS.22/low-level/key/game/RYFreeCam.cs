using System.Globalization;
using System.Numerics;
using static POS._22.Head;

namespace POS._22.low_level.key.game;

/// <summary>
/// Basic "freecam" / flight.
/// </summary>
// * Made by narcotics.
internal static class RYFreeCam
{
    #region Variables
    /// <summary>
    /// All pre-defined VKeys.
    /// </summary>
    private static readonly NativeInput[] keys = Enum.GetValues<NativeInput>();

    /// <summary>
    /// Thread for checking key-presses.
    /// </summary>
    private static readonly Thread keyThread = new(() =>
    {
        while (true)
            for (var i = 0; i < keys.Length; i++)
            {
                var key = keys[i];
                if (NativeKeyboard.IsKeyPressed(key))
                    OnKeyPressed(key);
            }
        // ReSharper disable once FunctionNeverReturns
    });

    /// <summary>
    /// Raw position value.
    /// </summary>
    private static readonly Vector2 currentPosition = Vector2.Zero;

    /// <summary>
    /// Raw new position.
    /// </summary>
    private static Vector2 newPosition = Vector2.Zero;

    /// <summary>
    /// The base movement speed.
    /// </summary>
    private static float baseSpeed = .004f;

    /// <summary>
    /// Write type.
    /// </summary>
    private const string type = "float";

    /// <summary>
    /// Y Position.
    /// </summary>
    private static float yPos = 90;
    #endregion

    /// <summary>
    /// Starts the key thread.
    /// </summary>
    public static void Setup()
    {
        if (!keyThread.IsAlive) keyThread.Start();
    }

    /// <summary>
    /// Kills the key thread.
    /// </summary>
    public static void Destroy()
    {
        if (keyThread.IsAlive) keyThread.Interrupt();
    }

    /// <summary>
    /// Called whenever a pre-defined key has been pressed.
    /// </summary>
    /// <param name="vKey"></param>
    private static void OnKeyPressed(NativeInput vKey)
    {
        switch (vKey)
        {
            case NativeInput.KEY_PLUS:
                baseSpeed += .000001f;
                break;
            case NativeInput.KEY_MINUS:
                baseSpeed -= .000001f;
                break;
            case NativeInput.KEY_SHIFT:
                yPos -= baseSpeed;
                break;
            case NativeInput.KEY_SPACE:
                yPos += baseSpeed;
                break;
            case NativeInput.KEY_W:
                newPosition.Y += baseSpeed;
                break;
            case NativeInput.KEY_A:
                newPosition.X -= baseSpeed;
                break;
            case NativeInput.KEY_S:
                newPosition.Y -= baseSpeed;
                break;
            case NativeInput.KEY_D:
                newPosition.X += baseSpeed;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(vKey), vKey,
                    "Invalid key (not pre-defined in NativeInput)!");
        }

        UpdatePosition();
    }

    /// <summary>
    /// Updates the camera position.
    /// </summary>
    private static void UpdatePosition()
    {
        var lerp = Lerp(currentPosition, newPosition);
        mem.WriteMemory(MemoryAddresses.camPosX, type, Convert.ToString(newPosition.X, CultureInfo.InvariantCulture));
        mem.WriteMemory(MemoryAddresses.camPosY, type, Convert.ToString(yPos, CultureInfo.InvariantCulture));
        mem.WriteMemory(MemoryAddresses.camPosZ, type, Convert.ToString(newPosition.Y, CultureInfo.InvariantCulture));
        // ! Prevent baseSpeed from going into the negatives or being 0
        if (baseSpeed <= 0) baseSpeed = .001f;
    }

    /// <summary>
    /// Lerp over a <see cref="Vector2"/>.
    /// </summary>
    /// <param name="in"></param>
    /// <param name="out"></param>
    /// <returns></returns>
    private static Vector2 Lerp(Vector2 @in, Vector2 @out) =>
        new(Lerp(@in.X, @out.X, .05f), Lerp(@out.Y, @out.Y, .05f));

    /// <summary>
    /// Lerp over a single <see cref="float"/> value.
    /// </summary>
    /// <param name="firstFloat"></param>
    /// <param name="secondFloat"></param>
    /// <param name="by"></param>
    /// <returns></returns>
    private static float Lerp(float firstFloat, float secondFloat, float by) =>
        firstFloat * (1 - by) + secondFloat * by;
}