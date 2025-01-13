using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MediHarbor.Models;

namespace MediHarbor.ViewModels
{
    public class TestScanViewModel
    {
        [Display(Name = "Search Term")]
        public string SearchTerm { get; set; }

        [Display(Name = "Search by Location")]
        public string Location { get; set; }

        [Display(Name = "Available From Date")]
        [DataType(DataType.Date)]
        public DateTime? AvailableFrom { get; set; }

        [Display(Name = "Available To Date")]
        [DataType(DataType.Date)]
        public DateTime? AvailableTo { get; set; }

        public List<Scan> Scans { get; set; } = new List<Scan>();
        public List<MedTest> MedTests { get; set; } = new List<MedTest>();
    }
}
