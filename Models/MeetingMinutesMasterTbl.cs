#nullable disable
namespace MeetingLogger.Models;public partial class MeetingMinutesMasterTbl
{
    public MeetingMinutesMasterTbl()
    {
        MeetingMinutesDetailsTbls = new HashSet<MeetingMinutesDetailsTbl>();
    }
    public int Id { get; set; }
    public string CustomerType { get; set; }
    public string CustomerName { get; set; }
    //public DateOnly? MeetingDate { get; set; }
    //public TimeOnly? MeetingTime { get; set; }

    public DateTime? MeetingDate { get; set; }
    public DateTime? MeetingTime { get; set; }
    public string MeetingPlace { get; set; }
    public string AttendsFromClientSide { get; set; }
    public string AttendsFromHostSide { get; set; }
    public string MeetingAgenda { get; set; }
    public string MeetingDiscussion { get; set; }
    public string MeetingDecision { get; set; }

    public virtual ICollection<MeetingMinutesDetailsTbl> MeetingMinutesDetailsTbls { get; set; }
}