namespace adventofcode2023
{
    public class NumberObject
    {
        public int Number { get; set; }
        public int Line { get; set; }
        public int Index { get; set; }
        public int Length { get; set; }
        public bool Status { get; set; }
        public bool Gear { get; set; }
        public GearSet? GearCords { get; set;}
    }
    public class GearSet
    {
        public int GearLine { get; set; }
        public int GearIndex { get; set; }
    }
}
