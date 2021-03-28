using System;
namespace TypewiseAlert
{
    public class ControllerAlert : IAlert
    {
        public bool IsAlertPublished(Constants.BreachType breachType)
        {
            Console.WriteLine("{0}\n", breachType);
            return true;
        }
    }
}