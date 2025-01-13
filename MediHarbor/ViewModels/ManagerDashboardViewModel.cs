using MediHarbor.Models;

namespace MediHarbor.ViewModels
{
    public class ManagerDashboardViewModel
    {
        public List<Scan> Scans { get; set; }
        public List<Doctor> Doctors { get; set; }
        public List<Appointment> Appointments { get; set; }
        public List<TextItem> Texts { get; set; }
    }
}

