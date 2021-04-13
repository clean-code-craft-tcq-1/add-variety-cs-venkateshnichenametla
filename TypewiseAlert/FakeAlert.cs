namespace TypewiseAlert
{
    public class FakeAlert : IAlert
    {
        public bool isCalledAtleastOnce = false;

        public void PublishAlert(string breachType)
        {
            isCalledAtleastOnce = true;
        }
    }
}
