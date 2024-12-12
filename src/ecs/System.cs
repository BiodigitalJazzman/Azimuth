
namespace Azimuth
{
    public static class System
    {
        private static Dictionary<Type, Storage> systems = new Dictionary<Type, Storage>();

        public static void RegisterComponent(Type componentType)
        {
            if (!systems.ContainsKey(componentType))
            {
                Debug.Log($"Registering component type: {componentType.Name}");
                systems[componentType] = new Storage(componentType);
            }
        }
        
        public static T Add<T>(Entity entity) where T : Component, new()
        {
            var component = new T();
            component.entity = entity;
            return (T)systems[typeof(T)].Add(component);
        }
        
        public static void Remove<T>(T element)
        {
            systems[typeof(T)].Remove(element);
        }

        public static T[] Get<T>()
        {
            return systems[typeof(T)].Get() as T[];
        }

        public static void Render()
        {
            foreach (var system in systems.Values)
            {
                foreach (var element in system.Get())
                {
                    Component component = (Component)element;
                    component.Invoke("Render");
                }
            }
        }

        public static void Update()
        {
            foreach (var system in systems.Values)
            {
                foreach (var element in system.Get())
                {
                    Component component = (Component)element;
                    component.Invoke("Update");
                }
            }
        }

        public static void GUI()
        {
            foreach (var system in systems.Values)
            {
                foreach (var element in system.Get())
                {
                    Component component = (Component)element;
                    component.Invoke("GUI");
                }
            }
        }

        public static void Gizmos()
        {
            foreach (var system in systems.Values)
            {
                foreach (var element in system.Get())
                {
                    Component component = (Component)element;
                    component.Invoke("Gizmos");
                }
            }
        }
    }
}
