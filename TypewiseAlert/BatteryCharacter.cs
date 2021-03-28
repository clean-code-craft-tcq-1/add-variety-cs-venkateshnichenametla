namespace TypewiseAlert
{
    public struct BatteryCharacter
    {
        public Constants.CoolingType coolingType;
        public string brand;
        public BatteryCharacter(Constants.CoolingType coolingType, string brand)
        {
            this.coolingType = coolingType;
            this.brand = brand;
        }
    }
}