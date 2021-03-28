namespace TypewiseAlert
{
    public class EmailAlert : IAlert
    {
        public bool IsAlertPublished(Constants.BreachType breachType)
        {
            string recepient = "abc@com";
            IBreach breach = new FactoryManager().GetInstance(breachType.ToString(), "IBreach") as IBreach;
            string breachMessage = breach.GetBreachMessage();
            return IsEmailSent(recepient, breachMessage);
        }
        private bool IsEmailSent(string recepient, string message)
        {
            //Setup of SMTP to trigger emails
            return true;
        }
    }
}