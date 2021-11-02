using System;

namespace EmmaSharper.Internals
{
    internal class DateRangeBuilder : IDateRangeToSelectionStage, IDateRangeOpenToSelectionStage
    {
        private readonly DateTime initialDate;

        internal DateRangeBuilder(DateTime date)
        {
            initialDate = date;
        }

        public DateRange To(DateTime date)
            => DateRange.Between(initialDate, date);

        public DateRange To(TimeSpan timespan)
            => To(initialDate.Add(timespan));

        public DateRange ToBeginning()
            => To(DateTime.MinValue);

        public DateRange ToEnd()
            => To(DateTime.MaxValue);

        public DateRange ToLatest()
            => To(DateTime.UtcNow);
    }
}
