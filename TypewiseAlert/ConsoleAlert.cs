using System;
namespace TypewiseAlert
{
    public class ConsoleAlert : IAlert
    {
        public void PublishAlert(string breachType)
        {
            Console.WriteLine("Breach is - " + breachType);
        }
    }
}
