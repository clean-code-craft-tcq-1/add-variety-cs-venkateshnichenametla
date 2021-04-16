namespace TypewiseAlert
{
    public class TypewiseAlert
    {
        private IAlert _alert;
        public TypewiseAlert(IAlert alert)
        {
            _alert = alert;
        }

        public TypewiseAlert()
        {

        }

        public string InferBreach(double value, double lowerLimit, double upperLimit)
        {
            IBreach breachTypeInstance = FactoryManager.Instance.GetClassObject("Normal", "IBreach") as IBreach;
            if (value < lowerLimit)
                breachTypeInstance = FactoryManager.Instance.GetClassObject("Low", "IBreach") as IBreach;
            else if (value > upperLimit)
                breachTypeInstance = FactoryManager.Instance.GetClassObject("High", "IBreach") as IBreach;
            return breachTypeInstance.GetBreachType();
        }

        public string ClassifyTemperatureBreach(string coolingType, double temperatureInC)
        {
            ICoolingType coolingTypeInstance = FactoryManager.Instance.GetClassObject(coolingType, "ICoolingType") as ICoolingType;
            return InferBreach(temperatureInC, coolingTypeInstance.LowerLimit, coolingTypeInstance.UpperLimit);
        }
        public void CheckAndAlert(BatteryCharacter batteryChar, double temperatureInC)
        {
            string breachType = ClassifyTemperatureBreach(batteryChar.coolingType, temperatureInC);
            _alert.PublishAlert(breachType);
        }
    }
}