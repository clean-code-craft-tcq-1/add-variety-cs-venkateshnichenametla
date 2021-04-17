namespace TypewiseAlert
{
    public class FakeAlert : IBreachObserver
    {
        public bool isCalledAtleastOnce = false;

        public void PublishAlert(string breachType)
        {
            isCalledAtleastOnce = true;
        }
    }
}
