#nullable disable

namespace MeetingLogger.Models.ViewModels
{
    public class MeetingMinutesViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string CustomerType { get; set; }

        [Required]
        [StringLength(100)]
        public string CustomerName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime MeetingDate { get; set; }
        //public DateOnly MeetingDate { get; set; }

        [Required]
        //[DataType(DataType.Time)]
        //public TimeSpan MeetingTime { get; set; }
        //public TimeOnly MeetingTime { get; set; }
        public DateTime MeetingTime { get; set; }

        [StringLength(100)]
        public string MeetingPlace { get; set; }

        [StringLength(100)]
        public string AttendsFromClientSide { get; set; }

        [StringLength(100)]
        public string AttendsFromHostSide { get; set; }

        [StringLength(int.MaxValue, MinimumLength = 3)]
        public string MeetingAgenda { get; set; }

        [StringLength(int.MaxValue, MinimumLength = 3)]
        public string MeetingDiscussion { get; set; }

        [StringLength(int.MaxValue, MinimumLength = 3)]
        public string MeetingDecision { get; set; }

        [Required]
        [StringLength(100)]
        public string ProductName { get; set; }

        [Required]
        [StringLength(50)]
        public string Unit { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be a positive number.")]
        public int Quantity { get; set; }
    }
}
