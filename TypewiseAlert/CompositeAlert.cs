using System.Collections.Generic;
namespace TypewiseAlert
{
    public class CompositeAlert : IBreachObserver
    {
        List<IBreachObserver> observers = new List<IBreachObserver>();

        public void AddBreachObserver(IBreachObserver breachObserver)
        {
            observers.Add(breachObserver);
        }
        public void PublishAlert(string breachType)
        {
            foreach (IBreachObserver observer in observers)
            {
                observer.PublishAlert(breachType);
            }
        }
    }
}
