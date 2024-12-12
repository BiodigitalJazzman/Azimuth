using Raylib_cs;
using System.Numerics;

namespace Azimuth
{
    public enum Key
    {
        Null = 0,
        Apostrophe = 39,
        Comma = 44,
        Minus = 45,
        Period = 46,
        Slash = 47,
        Zero = 48,
        One = 49,
        Two = 50,
        Three = 51,
        Four = 52,
        Five = 53,
        Six = 54,
        Seven = 55,
        Eight = 56,
        Nine = 57,
        Semicolon = 59,
        Equal = 61,
        A = 65,
        B = 66,
        C = 67,
        D = 68,
        E = 69,
        F = 70,
        G = 71,
        H = 72,
        I = 73,
        J = 74,
        K = 75,
        L = 76,
        M = 77,
        N = 78,
        O = 79,
        P = 80,
        Q = 81,
        R = 82,
        S = 83,
        T = 84,
        U = 85,
        V = 86,
        W = 87,
        X = 88,
        Y = 89,
        Z = 90,
        Space = 32,
        Escape = 256,
        Enter = 257,
        Tab = 258,
        Backspace = 259,
        Insert = 260,
        Delete = 261,
        Right = 262,
        Left = 263,
        Down = 264,
        Up = 265,
        F1 = 290,
        F2 = 291,
        F3 = 292,
        F4 = 293,
        F5 = 294,
        F6 = 295,
        F7 = 296,
        F8 = 297,
        F9 = 298,
        F10 = 299,
        F11 = 300,
        F12 = 301,
        LeftShift = 340,
        LeftControl = 341,
        LeftAlt = 342,
        RightShift = 344,
        RightControl = 345,
        RightAlt = 346
    }

    public enum Mouse
    {
        Left = 0,
        Right = 1,
        Middle = 2,
        Side = 3,
        Extra = 4,
        Forward = 5,
        Back = 6
    }

    public enum Gamepad
    {
        Unknown = 0,
        LeftFaceUp = 1,
        LeftFaceRight = 2,
        LeftFaceDown = 3,
        LeftFaceLeft = 4,
        RightFaceUp = 5,
        RightFaceRight = 6,
        RightFaceDown = 7,
        RightFaceLeft = 8,
        LeftTrigger1 = 9,
        LeftTrigger2 = 10,
        RightTrigger1 = 11,
        RightTrigger2 = 12,
        MiddleLeft = 13,
        Middle = 14,
        MiddleRight = 15,
        LeftThumb = 16,
        RightThumb = 17
    }

    public enum Axis
    {
        LeftX = 0,
        LeftY = 1,
        RightX = 2,
        RightY = 3,
        LeftTrigger = 4,
        RightTrigger = 5
    }

    public static class Input 
    {
        // Keyboard Input
        public static bool GetKeyDown(Key key) => Raylib.IsKeyPressed((KeyboardKey)key);
        public static bool GetKey(Key key) => Raylib.IsKeyDown((KeyboardKey)key);
        public static bool GetKeyUp(Key key) => Raylib.IsKeyReleased((KeyboardKey)key);
        
        // Mouse Input
        public static bool GetMouseButtonDown(Mouse button) => Raylib.IsMouseButtonPressed((MouseButton)button);
        public static bool GetMouseButton(Mouse button) => Raylib.IsMouseButtonDown((MouseButton)button);
        public static bool GetMouseButtonUp(Mouse button) => Raylib.IsMouseButtonReleased((MouseButton)button);
        
        public static Vector2 mousePosition => Raylib.GetMousePosition();
        public static float mouseScrollDelta => Raylib.GetMouseWheelMove();
        public static Vector2 mouseDelta => Raylib.GetMouseDelta();

        // Gamepad Input
        public static bool IsGamepadAvailable(int gamepad) => Raylib.IsGamepadAvailable(gamepad);
        public static bool GetGamepadButtonDown(int gamepad, Gamepad button) => Raylib.IsGamepadButtonPressed(gamepad, (GamepadButton)button);
        public static bool GetGamepadButton(int gamepad, Gamepad button) => Raylib.IsGamepadButtonDown(gamepad, (GamepadButton)button);
        public static bool GetGamepadButtonUp(int gamepad, Gamepad button) => Raylib.IsGamepadButtonReleased(gamepad, (GamepadButton)button);
        public static float GetGamepadAxis(int gamepad, Axis axis) => Raylib.GetGamepadAxisMovement(gamepad, (GamepadAxis)axis);
    }
}
