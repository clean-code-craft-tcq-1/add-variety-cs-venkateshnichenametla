using System;
namespace TypewiseAlert
{
    public class ControllerAlert : IBreachObserver
    {
        public void PublishAlert(string breachType)
        {
            Console.WriteLine("{0}\n", breachType);
        }
    }
}