namespace TypewiseAlert
{
    public class FakeAlert : IAlert, IFakeAlert
    {
        public bool isCalledAtleastOnce = false;

        public bool IsAlertPublished()
        {
            return isCalledAtleastOnce;
        }

        public void PublishAlert(string breachType)
        {
            isCalledAtleastOnce = true;
        }
    }
}
