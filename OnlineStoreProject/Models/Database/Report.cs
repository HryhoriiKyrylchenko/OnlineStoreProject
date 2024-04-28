using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using OnlineStoreProject.Enums;

namespace OnlineStoreProject.Models.Database
{
    public class Report
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public DateTime ReportDate { get; set; }

        [Required]
        public ReportTypeEnum ReportType { get; set; }

        public string Content { get; set; }

        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User? User { get; set; }

        public Report(string title, DateTime reportDate, ReportTypeEnum reportType, string content, int userId)
        {
            Title = title;
            ReportDate = reportDate;
            ReportType = reportType;
            Content = content;
            UserId = userId;
        }
    }
}
