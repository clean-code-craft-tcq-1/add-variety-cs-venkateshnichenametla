namespace TypewiseAlert
{
    public class HighBreach : IBreach
    {
        public string GetBreachMessage()
        {
            return "Hi, the temperature is too high\n";
        }

        public string GetBreachType()
        {
            return "High";
        }
    }
}