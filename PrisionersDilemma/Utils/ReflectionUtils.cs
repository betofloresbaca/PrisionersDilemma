using System.Reflection;

namespace PrisionersDilemma.Utils
{
    internal static class ReflectionUtils
    {
        public static List<Type> GetTypesImplementingInterface<T>(string? namespc = null)
        {
            var interfaceType = typeof(T);
            var assembly = Assembly.GetExecutingAssembly();
            var types = assembly
                .GetTypes()
                .Where(t => interfaceType.IsAssignableFrom(t) && t.IsClass && !t.IsAbstract)
                .Where(t => namespc == null || t.Namespace == namespc)
                .ToList();
            return types;
        }

        public static IType CreateInstance<IType>(Type type)
        {
            return (IType)Activator.CreateInstance(type);
        }

        public static List<IType> CreateInstances<IType>(List<Type> types)
        {
            var instances = new List<IType>();
            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type);
                instances.Add((IType)instance);
            }
            return instances;
        }
    }
}
