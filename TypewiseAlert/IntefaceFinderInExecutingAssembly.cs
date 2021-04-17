using System;
using System.Reflection;
namespace TypewiseAlert
{
    public static class IntefaceFinderInExecutingAssembly
    {
        public static Type GetInterfaceInExecutingAssembly(string className, string typeName)
        {
            Type retValue = null;
            foreach (Type type in Assembly.Load(Assembly.GetExecutingAssembly().GetName()).GetTypes())
            {
                if (type.GetInterface(typeName) == null)
                    continue;
                if (type.Name.ToLower().Contains(className.ToLower()))
                {
                    retValue = type;
                    break;
                }
            }
            return retValue;
        }
    }
}