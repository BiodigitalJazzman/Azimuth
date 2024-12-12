
using System.Diagnostics.Tracing;

namespace Azimuth
{
    public static class Level
    {
        public static void Enter()
        {
            ECS.Enter();
        }

        public static void Render()
        {
            ECS.Render();
        }

        public static void GUI()
        {
            ECS.GUI();
        }
        
        public static void Gizmos()
        {
            ECS.Gizmos();
        }

        public static void Update()
        {
            ECS.Update();
        }

        public static void Add(Entity entity)
        {
            ECS.Add(entity);
        }

        public static void Remove(Entity entity)
        {
            ECS.Remove(entity);
        }

        public static void Exit()
        {
            ECS.Exit();
        }
    }
}
