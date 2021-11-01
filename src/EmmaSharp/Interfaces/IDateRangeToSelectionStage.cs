namespace EmmaSharp
{
    public interface IDateRangeToSelectionStage : IDateRangeOpenToSelectionStage
    {
        DateRange ToBeginning();

        DateRange ToEnd();
    }
}
