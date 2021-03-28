using System;
namespace TypewiseAlert
{
    public class FactoryManager
    {
        public Object GetInstance(string className, string typeName)
        {
            Type typeAssembly = IntefaceFinderInExecutingAssembly.GetInterfaceInExecutingAssembly(className, typeName);
            return (typeAssembly == null) ? throw new EntryPointNotFoundException("class not found") : Activator.CreateInstance(typeAssembly);
        }
    }
}