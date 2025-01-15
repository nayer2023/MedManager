using System;
using System.ComponentModel.DataAnnotations;

namespace MediHarbor.ViewModels
{
    public class DocApptViewModel
    {
        [Required]
        [Display(Name = "Select Doctor")]
        public int DoctorID { get; set; }

        [Required]
        [Display(Name = "Appointment Date & Time")]
        public DateTime AppointmentDate { get; set; }

        [Required]
        [Display(Name = "Reason for Visit")]
        public string Reason { get; set; }
    }
}
