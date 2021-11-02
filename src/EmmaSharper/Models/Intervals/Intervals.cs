using System.Collections;

namespace EmmaSharper
{
    public class Intervals : IEnumerable
    {
        public Interval Key { get; set; }
        public int Value { get; set; }

        public Intervals(Interval Key, int Value)
        {
            this.Key = Key;
            this.Value = Value;
        }

        public IEnumerator GetEnumerator() => GetEnumerator();
    }
}
