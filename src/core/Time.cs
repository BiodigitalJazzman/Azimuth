using Raylib_cs;

namespace Azimuth
{
    public static class Time
    {
        public static float TimeScale = 1;
        public static float DeltaTime => Raylib.GetFrameTime() * TimeScale;
    }
}