namespace MeetingLogger.Data
{
    public partial interface IApplicationDbContextProcedures
    {
        Task<int> Meeting_Minutes_Details_Save_SPAsync(int? MeetingId, int? ProductId, int? Quantity, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> Meeting_Minutes_Master_Save_SPAsync(string CustomerType, string CustomerName, DateOnly? MeetingDate, TimeOnly? MeetingTime, string MeetingPlace, string AttendsFromClientSide, string AttendsFromHostSide, string MeetingAgenda, string MeetingDiscussion, string MeetingDecision, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
    }
}
