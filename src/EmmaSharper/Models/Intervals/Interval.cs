namespace EmmaSharper
{
    public sealed class Interval
    {
        private readonly string name;

        public static readonly Interval Year = new Interval("year");
        public static readonly Interval Month = new Interval("month");
        public static readonly Interval Day = new Interval("day");
        public static readonly Interval Hour = new Interval("hour");
        public static readonly Interval Minute = new Interval("minute");
        public static readonly Interval Second = new Interval("second");

        private Interval(string name)
        {
            this.name = name;
        }

        public override string ToString() => name;
    }
}
