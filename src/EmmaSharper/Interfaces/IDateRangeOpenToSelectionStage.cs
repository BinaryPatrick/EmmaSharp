using System;

namespace EmmaSharper
{
    /// <summary><see cref="DateRange"/> builder on the <see cref="DateRange.RangeEnd"/> selection step</summary>
    public interface IDateRangeOpenToSelectionStage
    {
        /// <summary>Sets the <see cref="DateRange.RangeEnd"/> to a specific date</summary>
        DateRange To(DateTime date);

        /// <summary>Sets a specific amount of time to end the date range at from the given <see cref="DateRange.RangeStart"/> value</summary>
        /// <remarks>Timespan can be negative</remarks>
        DateRange To(TimeSpan timespan);

        /// <summary>Sets the <see cref="DateRange.RangeEnd"/> to the current timestamp</summary>
        DateRange ToLatest();
    }
}
