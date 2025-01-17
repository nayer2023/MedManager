using System.ComponentModel.DataAnnotations;

namespace MediHarbor.Models
{
    public class TextItem
    {
        [Key]
        public int TextID { get; set; }

        [Required]
        [Display(Name = "Content")]
        public string Content { get; set; }

        [Display(Name = "Date Created")]
        public DateTime DateCreated { get; set; } = DateTime.Now;

        [Display(Name = "Last Modified")]
        public DateTime? LastModified { get; set; }

        [Display(Name = "Category")]
        public string Category { get; set; } 

       
        public string ManagerId { get; set; }
    }
}
