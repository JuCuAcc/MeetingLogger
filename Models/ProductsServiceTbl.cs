#nullable disable
namespace MeetingLogger.Models;
public partial class ProductsServiceTbl
{
    public ProductsServiceTbl()
    {
        MeetingMinutesDetailsTbls = new HashSet<MeetingMinutesDetailsTbl>();
    }
    public int Id { get; set; }
    public string ProductName { get; set; }
    public string Unit { get; set; }

    public virtual ICollection<MeetingMinutesDetailsTbl> MeetingMinutesDetailsTbls { get; set; }
}