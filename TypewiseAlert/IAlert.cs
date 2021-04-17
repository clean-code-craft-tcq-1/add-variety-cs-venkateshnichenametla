namespace TypewiseAlert
{
    public interface IBreachObserver
    {
        void PublishAlert(string breachType);
    }
}