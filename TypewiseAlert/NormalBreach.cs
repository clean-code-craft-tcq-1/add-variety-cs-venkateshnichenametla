namespace TypewiseAlert
{
    public class NormalBreach : IBreach
    {
        public string GetBreachMessage()
        {
            return "Hi, the temperature is Normal\n";
        }

        public string GetBreachType()
        {
            return "Normal";
        }
    }
}
