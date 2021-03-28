namespace TypewiseAlert
{
    public class TypewiseAlert
    {
        public static Constants.BreachType InferBreach(double value, double lowerLimit, double upperLimit)
        {
            if (value < lowerLimit)
                return Constants.BreachType.Low;
            if (value > upperLimit)
                return Constants.BreachType.High;
            return Constants.BreachType.Normal;
        }

        public static Constants.BreachType ClassifyTemperatureBreach(Constants.CoolingType coolingType, double temperatureInC)
        {
            ICoolingType coolingTypeInstance = new FactoryManager().GetInstance(coolingType.ToString(), "ICoolingType") as ICoolingType;
            return InferBreach(temperatureInC, coolingTypeInstance.LowerLimit, coolingTypeInstance.UpperLimit);
        }
        public static bool CheckAndAlert(Constants.AlertTarget alertTarget, BatteryCharacter batteryChar, double temperatureInC)
        {
            Constants.BreachType breachType = ClassifyTemperatureBreach(batteryChar.coolingType, temperatureInC);
            IAlert alert = new FactoryManager().GetInstance(alertTarget.ToString(), "IAlert") as IAlert;
            return alert.IsAlertPublished(breachType);
        }
    }
}