using System.ComponentModel.DataAnnotations;

namespace MediHarbor.Models
{
    public class MedTest
    {
        [Key] 
        public int BloodTestID { get; set; }

        [Required]
        [Display(Name = "Test Name")]
        public string TestName { get; set; }

        [Required]
        [Display(Name = "Test Category")]
        public string TestCategory { get; set; }  

        [Required]
        public string Location { get; set; }

        [Required]
        [Display(Name = "Available Date")]
        [DataType(DataType.Date)]
        public DateTime AvailableDate { get; set; }

        [Display(Name = "Price")]
        [Range(0, 10000)]
        public decimal? Price { get; set; }

        [Display(Name = "Fasting Required?")]
        public bool FastingRequired { get; set; } 

        [Display(Name = "Description")]
        public string Description { get; set; }
    }
}
