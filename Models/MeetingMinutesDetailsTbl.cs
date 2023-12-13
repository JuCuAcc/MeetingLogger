#nullable disable
namespace MeetingLogger.Models;public partial class MeetingMinutesDetailsTbl
{
    public int Id { get; set; }
    public int? MeetingId { get; set; }
    public int? ProductId { get; set; }
    public int? Quantity { get; set; }

    public virtual MeetingMinutesMasterTbl Meeting { get; set; }
    public virtual ProductsServiceTbl Product { get; set; }
}