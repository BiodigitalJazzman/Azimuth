
using Raylib_cs;

namespace Azimuth
{
    public static class Editor
    {
        // settings
        private static bool playing = false;
        private static bool paused  = false;
        private static bool gizmos  = false;

        // properties
        public static bool IsPlaying { get => playing; }
        public static bool IsPaused  { get => paused;  }
        public static bool IsGizmos  { get => gizmos;  }

        // methods
        public static void Enter()
        {
            
        }

        public static void Update()
        {
            if(Input.GetKeyDown(Key.F5))
            {
                if(playing) Stop();
                else Play();
            }

            if(Input.GetKeyDown(Key.F6))
            {
                if(playing) Pause();
                else if(paused) Play();
            }

            if(Input.GetKeyDown(Key.F7)) gizmos = !gizmos;

            if(playing)
            {
                Level.Update();
            }
        }

        public static void Render()
        {
            if(gizmos) 
            {
                Gizmos();
            }
        }

        public static void GUI()
        {
            Window.Title = "Azimuth Game Engine | Editor | " + (playing ? "Playing" : paused ? "Paused" : "Editing") + (gizmos ? " | Debug" : "");
            Raylib.DrawFPS(10, 10);
        }

        public static void Gizmos()
        {
            Level.Gizmos();
        }

        public static void Exit()
        {

        }

        private static void Play()
        {
            if(playing) Stop();

            playing = true;
            paused  = false;
        }

        private static void Pause()
        {
            if(!playing) return;

            playing = false;
            paused  = true;
        }

        private static void Stop()
        {
            if(!playing) return;

            playing = false;
            paused  = false;
        }
    }
}