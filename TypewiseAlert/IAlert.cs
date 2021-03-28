namespace TypewiseAlert
{
    public interface IAlert
    {
        bool IsAlertPublished(Constants.BreachType breachType);
    }
}