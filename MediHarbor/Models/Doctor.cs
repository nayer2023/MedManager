using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace MediHarbor.Models
{
    public class Doctor
    {
        [Key]  
        public int DoctorID { get; set; }

        [Required]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Required]
        [Display(Name = "Specialization")]
        public string Specialization { get; set; } 
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Location")]
        public string Location { get; set; }

        [ForeignKey("IdentityUser")] 
        public string UserId { get; set; }
        public IdentityUser User { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
    }
}
