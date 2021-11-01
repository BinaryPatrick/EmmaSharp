using System;

namespace EmmaSharp
{
    public interface IDateRangeOpenToSelectionStage
    {
        DateRange To(DateTime date);

        DateRange To(TimeSpan timespan);

        DateRange ToLatest();
    }
}
