namespace TypewiseAlert
{
    public class LowBreach : IBreach
    {
        public string GetBreachMessage()
        {
            return "Hi, the temperature is too low\n";
        }

        public string GetBreachType()
        {
            return "Low";
        }
    }
}