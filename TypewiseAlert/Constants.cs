namespace TypewiseAlert
{
    public class Constants
    {
        public enum BreachType
        {
            Normal,
            Low,
            High
        }
        public enum CoolingType
        {
            PassiveCooling,
            HiActiveCooling,
            MediumActiveCooling
        }
        public enum AlertTarget
        {
            Controller,
            Email
        }
    }
}