namespace TypewiseAlert
{
    public struct BatteryCharacter
    {
        public string coolingType;
        public string brand;
        public BatteryCharacter(string coolingType, string brand)
        {
            this.coolingType = coolingType;
            this.brand = brand;
        }
    }
}