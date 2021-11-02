using System;
using EmmaSharper.Internals;

namespace EmmaSharper
{
    /// <summary>Represents a date range from two <see cref="Nullable"/>&lt;<see cref="DateTime"/>&gt;s</summary>
    /// <remarks>Initialize using static <see cref="From"/> methods</remarks>
    public struct DateRange
    {
        /// <inheritdoc cref="object.Object"/>
        public DateRange(DateTime rangeStart, DateTime rangeEnd)
        {
            RangeStart = rangeStart;
            RangeEnd = rangeEnd;
        }

        /// <summary>Range start date</summary>
        public DateTime RangeStart { get; private set; }

        /// <summary>Range end date</summary>
        public DateTime RangeEnd { get; private set; }

        /// <summary>Creates a date range between two timestamps</summary>
        /// <remarks>Timestamps can be given in any order</remarks>
        public static DateRange Between(DateTime date1, DateTime date2)
            => date1 < date2 ? new DateRange(date1, date2) : new DateRange(date2, date1);

        /// <summary>Builds a <see cref="DateRange"/> starting from the given timestamp</summary>
        public static IDateRangeToSelectionStage From(DateTime date)
            => new DateRangeBuilder(date);

        /// <summary>Builds a <see cref="DateRange"/> starting from the current timestamp</summary>
        public static IDateRangeToSelectionStage FromLatest()
            => new DateRangeBuilder(DateTime.UtcNow);

        /// <summary>Builds a <see cref="DateRange"/> starting from <see cref="DateTime.MinValue"/></summary>
        public static IDateRangeOpenToSelectionStage FromBegining()
            => new DateRangeBuilder(DateTime.MinValue);

        /// <summary>Builds a <see cref="DateRange"/> starting from <see cref="DateTime.MaxValue"/></summary>
        public static IDateRangeOpenToSelectionStage FromEnd()
            => new DateRangeBuilder(DateTime.MaxValue);

        /// <summary>Build a DateRage string for use in API call</summary>
        public override string ToString()
            => $"{GetDatestamp(RangeStart)}~{GetDatestamp(RangeEnd)}";

        private string GetDatestamp(DateTime? date)
           => date.HasValue ? date.Value.ToString("yyyy-MM-dd") : string.Empty;
    }
}
