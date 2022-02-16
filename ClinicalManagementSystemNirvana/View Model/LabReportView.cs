using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicalManagementSystemNirvana.View_Model
{
    public class LabReportView
    {
        public int ReportId { get; set; }
        public DateTime? ReportDate { get; set; }
        public string Doctor { get; set; }
        public string Patient { get; set; }
        public string BloodGroup { get; set; }
        public string  PhnNo { get; set; }
        public int? AppointmentId { get; set; }
        public List<TestView> Tests { get; set; }
    }
}
