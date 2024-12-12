using System.Reflection;
using System.Collections.Generic;
using System.Linq;

namespace Azimuth
{
    public class Entity
    {
        public List<Component> components = new List<Component>();

        // event settings
        public bool isAwake = false;

        public Entity()
        {
            components = new List<Component>();

            // default components
            AddComponent<Transform>();
        }

        public T AddComponent<T>() where T : Component, new()
        {
            var component = System.Add<T>(this);
            components.Add(component);
            return component;
        }

        public void RemoveComponent<T>(T component) where T : Component, new()
        {
            components.Remove(component);
            System.Remove(component);
        }

        public bool HasComponent<T>() where T : Component, new()
        {
            return components.Any(c => c.GetType() == typeof(T));
        }

        public T[] GetComponents<T>() where T : Component, new()
        {
            return System.Get<T>();
        }

        public void Invoke(string methodName, params object[] args)
        {
            foreach (var component in components)
            {
                component.Invoke(methodName, args);
            }
        }

        // dont get confused this is not to update functions. just the gameobject class
        public void Update()
        {
            // GetComponents<Transform>()
        }

        // dont get confused this is not to update functions. just the gameobject class
        public void Render()
        {

        }

        // dont get confused this is not to update functions. just the gameobject class
        public void GUI()
        {

        }

        // dont get confused this is not to update functions. just the gameobject class
        public void Gizmos()
        {

        }
    }
}

