namespace TypewiseAlert
{
    public class TypewiseAlert
    {
        public static string InferBreach(double value, double lowerLimit, double upperLimit)
        {
            IBreach breachTypeInstance = FactoryManager.Instance.GetClassObject("Normal", "IBreach") as IBreach;
            if (value < lowerLimit)
                breachTypeInstance = FactoryManager.Instance.GetClassObject("Low", "IBreach") as IBreach;
            else if (value > upperLimit)
                breachTypeInstance = FactoryManager.Instance.GetClassObject("High", "IBreach") as IBreach;
            return breachTypeInstance.GetBreachType();
        }

        public static string ClassifyTemperatureBreach(string coolingType, double temperatureInC)
        {
            ICoolingType coolingTypeInstance = FactoryManager.Instance.GetClassObject(coolingType, "ICoolingType") as ICoolingType;
            return InferBreach(temperatureInC, coolingTypeInstance.LowerLimit, coolingTypeInstance.UpperLimit);
        }
        public static void CheckAndAlert(string alertTarget, BatteryCharacter batteryChar, double temperatureInC)
        {
            string breachType = ClassifyTemperatureBreach(batteryChar.coolingType, temperatureInC);
            IAlert alert = FactoryManager.Instance.GetClassObject(alertTarget, "IAlert") as IAlert;
            alert.PublishAlert(breachType);
        }
    }
}