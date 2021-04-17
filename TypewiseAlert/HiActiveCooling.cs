namespace TypewiseAlert
{
    class HiActiveCooling : ICoolingType
    {
        public int LowerLimit { get { return 0; } }
        public int UpperLimit { get { return 45; } }
    }
}