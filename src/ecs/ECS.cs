using System.Reflection;
using System.Linq;
using System.Collections.Generic;

namespace Azimuth
{
    public static class ECS
    {
        public static List<Entity> entities = new List<Entity>();

        public static void Enter()
        {
            var componentTypes = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract && t.IsSubclassOf(typeof(Component)))
                .ToList();

            foreach (var type in componentTypes) System.RegisterComponent(type);
        }

        public static void Exit()
        {
            // nothing atm
        }

        public static void Add(Entity entity)
        {
            entities.Add(entity);
        }

        public static void Remove(Entity entity)
        {
            entity.Invoke("Destroy");
            entities.Remove(entity);
        }

        public static void Update()
        {
            foreach (var entity in entities)
            {
                if (!entity.isAwake)
                {
                    entity.isAwake = true;
                    entity.Invoke("Awake");
                }
            }

            foreach (var entity in entities) entity.Update();
            System.Update();
        }

        public static void Render()
        {
            foreach (var entity in entities) entity.Render();
            System.Render();
        }

        public static void GUI()
        {
            foreach (var entity in entities) entity.GUI();
            System.GUI();
        }

        public static void Gizmos()
        {
            foreach (var entity in entities) entity.Gizmos();
            System.Gizmos();
        }
    }
}
