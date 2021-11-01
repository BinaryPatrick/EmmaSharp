using System;
using EmmaSharp.Internals;

namespace EmmaSharp
{
    /// <summary>Represents a date range from two <see cref="Nullable"/>&lt;<see cref="DateTime"/>&gt;s</summary>
    /// <remarks>Initialize using static <see cref="From"/> methods</remarks>
    public struct DateRange
    {
        public DateRange(DateTime rangeStart, DateTime rangeEnd)
        {
            RangeStart = rangeStart;
            RangeEnd = rangeEnd;
        }

        /// <summary>Range start date</summary>
        public DateTime RangeStart { get; private set; }

        /// <summary>Range end date</summary>
        public DateTime RangeEnd { get; private set; }

        public static DateRange Between(DateTime date1, DateTime date2)
            => date1 < date2 ? new DateRange(date1, date2) : new DateRange(date2, date1);

        public static IDateRangeToSelectionStage From(DateTime date)
            => new DateRangeBuilder(date);

        public static IDateRangeToSelectionStage FromLatest()
            => new DateRangeBuilder(DateTime.UtcNow);

        public static IDateRangeOpenToSelectionStage FromBegining()
            => new DateRangeBuilder(DateTime.MinValue);

        public static IDateRangeOpenToSelectionStage FromEnd()
            => new DateRangeBuilder(DateTime.MaxValue);

        /// <summary>
        /// Build a DateRage string for use in API calls. Use Optional SpecificDate attribute to specify a single 
        /// date using only the Start date; End date will be ignored.
        /// </summary>
        /// <param name="range">A date range object.</param>
        /// <returns>A range string to be used in Response API calls.</returns>
        public override string ToString()
            => $"{GetDatestamp(RangeStart)}~{GetDatestamp(RangeEnd)}";

        private string GetDatestamp(DateTime? date)
           => date.HasValue ? date.Value.ToString("yyyy-MM-dd") : string.Empty;
    }
}
