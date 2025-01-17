using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace MediHarbor.Models
{
    public class Patient
    {
        [Key]
        public int PatientID { get; set; }

        [Required]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Required]
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Gender")]
        public string Gender { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; }

        // Foreign key to link with IdentityUser
        [Required]
        [ForeignKey("IdentityUser")]
        public string UserId { get; set; }  

        public IdentityUser User { get; set; }  

       
        public ICollection<Appointment> Appointments { get; set; }
    }
}
