namespace TypewiseAlert
{
    public class MediumActiveCooling : ICoolingType
    {
        public int LowerLimit { get { return 0; } }
        public int UpperLimit { get { return 40; } }
    }
}