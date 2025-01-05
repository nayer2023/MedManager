using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MediHarbor.Models
{
    public class Appointment
    {
        [Key]  
        public int AppointmentID { get; set; }

        [Required]
        [ForeignKey("Patient")]  
        public int PatientID { get; set; }
        public Patient Patient { get; set; }  
        [Required]
        [ForeignKey("Doctor")]  
        public int DoctorID { get; set; }
        public Doctor Doctor { get; set; } 

        [Required]
        [Display(Name = "Appointment Date & Time")]
        public DateTime AppointmentDate { get; set; }

        [Required]
        [Display(Name = "Reason for Visit")]
        public string Reason { get; set; }

        [Display(Name = "Status")]
        public string Status { get; set; } = "Scheduled"; 

        [Display(Name = "Created On")]
        public DateTime CreatedOn { get; set; } = DateTime.Now;
    }
}
