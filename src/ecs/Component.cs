using System.Reflection;
using System.Collections.Generic;

namespace Azimuth
{
    public class Component
    {
        public Entity entity;

        private static List<MethodInfo> methods = null;
        public List<MethodInfo> Methods(){

            if(methods == null){
                methods = GetType().GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly).ToList();
            }

            return methods;
        }

        private static List<FieldInfo> fields = null;
        public List<FieldInfo> Fields(){

            if(fields == null){
                fields = GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly).ToList();
            }

            return fields;
        }

        private static List<PropertyInfo> properties = null;
        public List<PropertyInfo> Properties(){

            if(properties == null){
                properties = GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly).ToList();
            }

            return properties;
        }

        public void Invoke(string methodName, params object[] args){
            var method = Methods().FirstOrDefault(m => m.Name == methodName);
            if(method != null){
                method.Invoke(this, args);
            }
        }
    }
}
