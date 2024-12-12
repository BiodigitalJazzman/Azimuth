using Raylib_cs;
using System.Numerics;

namespace Azimuth
{
    public static class Camera
    {
        private static Camera2D camera = new Camera2D();

        public static Vector2 Position
        {
            get => camera.Target;
            set => camera.Target = value;
        }

        public static Vector2 Offset
        {
            get => camera.Offset;
            set => camera.Offset = value;
        }

        public static float Rotation
        {
            get => camera.Rotation;
            set => camera.Rotation = value;
        }

        public static float Zoom
        {
            get => camera.Zoom;
            set => camera.Zoom = value;
        }

        public static void Begin()
        {
            Raylib.BeginMode2D(camera);
        }

        public static void End()
        {
            Raylib.EndMode2D();
        }

        public static void Enter()
        {            
            camera.Zoom = 1.0f;
            camera.Rotation = 0.0f;
            camera.Offset = new Vector2(Window.Width / 2.0f, Window.Height / 2.0f);
            camera.Target = Vector2.Zero;
        }

        public static void Exit()
        {

        }
    }
}