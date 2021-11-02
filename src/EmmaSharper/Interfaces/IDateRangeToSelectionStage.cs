using System;

namespace EmmaSharper
{
    /// <inheritdoc/>
    public interface IDateRangeToSelectionStage : IDateRangeOpenToSelectionStage
    {
        /// <summary>Sets the <see cref="DateRange.RangeEnd"/> to <see cref="DateTime.MinValue"/></summary>
        DateRange ToBeginning();

        /// <summary>Sets the <see cref="DateRange.RangeEnd"/> to <see cref="DateTime.MaxValue"/></summary>
        DateRange ToEnd();
    }
}
