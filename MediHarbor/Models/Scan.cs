using System;
using System.ComponentModel.DataAnnotations;

namespace MediHarbor.Models
{
    public class Scan
    {
        [Key]
        public int ScanID { get; set; }

        [Required]
        [Display(Name = "Scan Type")]
        public string ScanType { get; set; }

        [Required]
        [Display(Name = "Body Part")]
        public string BodyPart { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        [Display(Name = "Available Date")]
        [DataType(DataType.Date)]
        public DateTime AvailableDate { get; set; }

        [Display(Name = "Price")]
        [Range(0, 10000)]
        public decimal? Price { get; set; }

        [Display(Name = "Duration (minutes)")]
        public int? Duration { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        
        public string ManagerId { get; set; }
    }
}
