using System;
namespace TypewiseAlert
{
    public sealed class FactoryManager
    {
        private static readonly object lockObject = new object();
        private static FactoryManager instance = null;
        public static FactoryManager Instance
        {
            get
            {
                lock (lockObject)
                {
                    if (instance == null)
                        instance = new FactoryManager();
                    return instance;
                }
            }
        }
        public Object GetClassObject(string className, string typeName)
        {
            Type typeAssembly = IntefaceFinderInExecutingAssembly.GetInterfaceInExecutingAssembly(className, typeName);
            return (typeAssembly == null) ? throw new EntryPointNotFoundException("class not found") : Activator.CreateInstance(typeAssembly);
        }
    }
}