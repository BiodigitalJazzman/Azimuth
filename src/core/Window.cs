using Raylib_cs;

namespace Azimuth
{
    public static class Window
    {
        // settings
        private static string title = "Azimuth";
        private static int width = 1280;
        private static int height = 720;

        // properties
        public static string Title {
            get => title;
            set {
                title = value;
                Raylib.SetWindowTitle(title);
            }
        }

        public static int Width {
            get => width;
            set {
                width = value;
                Raylib.SetWindowSize(width, height);
            }
        }

        public static int Height {
            get => height;
            set {
                height = value;
                Raylib.SetWindowSize(width, height);
            }
        }

        public static bool IsOpen { get => !Raylib.WindowShouldClose(); }

        public static bool IsFullscreen { get => Raylib.IsWindowFullscreen(); } 

        public static bool IsFocused { get => Raylib.IsWindowFocused(); }

        // methods
        public static void Enter()
        {
            

            // hide raylib logs
            Raylib.SetTraceLogLevel(TraceLogLevel.None);

            // initialize window
            Raylib.SetConfigFlags(ConfigFlags.ResizableWindow);
            Raylib.InitWindow(width, height, title);
            Raylib.SetTargetFPS(240); // only cause it seems to average one bellow 240

            // init camera
            Camera.Enter();
        }

        public static void Begin()
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.Black);
        }

        public static void End()
        {
            Raylib.EndDrawing();
        }

        public static void Update()
        {

        }

        public static void Exit()
        {
            Raylib.CloseWindow();
        }
    }
}

