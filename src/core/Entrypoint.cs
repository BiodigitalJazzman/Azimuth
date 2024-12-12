namespace Azimuth
{
    public static class Entrypoint
    {
        public static void Main(string[] args)
        {
            Enter();

            Entity entity = new Entity();
            Level.Add(entity);

            while (Application.IsRunning)
            {
                Render();
                Update();
            }

            Exit();
        }

        private static void Enter()
        {
            Window.Enter();
            Level.Enter();

            #if EDITOR
                Editor.Enter();
            #endif
        }

        private static void Render()
        {
            Window.Begin();

            // World Space
            Camera.Begin();
                Level.Render();

            #if EDITOR
                Editor.Render();
            #endif

            Camera.End();   

            // Screen Space
            Level.GUI();

            #if EDITOR
                Editor.GUI();
            #endif

            Window.End();
        }

        private static void Update()
        {
            #if EDITOR
                Editor.Update();
            #endif

            #if !EDITOR
                Level.Update();
            #endif

            Textures.Update();
        }

        private static void Exit()
        {
            Level.Exit();

            #if EDITOR
                Editor.Exit();
            #endif

            Window.Exit();
        }
    }
}