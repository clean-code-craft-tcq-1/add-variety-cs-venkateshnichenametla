namespace TypewiseAlert
{
    public class EmailAlert : IBreachObserver
    {
        public void PublishAlert(string breachType)
        {
            string recepient = "abc@com";
            IBreach breach = FactoryManager.Instance.GetClassObject(breachType, "IBreach") as IBreach;
            string breachMessage = breach.GetBreachMessage();
            SendMail(recepient, breachMessage);
        }
        private void SendMail(string recepient, string message)
        {
            //Setup of SMTP to trigger emails
        }
    }
}