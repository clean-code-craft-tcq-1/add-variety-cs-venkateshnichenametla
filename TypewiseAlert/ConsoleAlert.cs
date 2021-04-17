using System;
namespace TypewiseAlert
{
    public class ConsoleAlert : IBreachObserver
    {
        public void PublishAlert(string breachType)
        {
            Console.WriteLine("Breach is - " + breachType);
        }
    }
}
