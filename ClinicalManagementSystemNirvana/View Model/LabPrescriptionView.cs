using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicalManagementSystemNirvana.View_Model
{
    public class LabPrescriptionView
    {
        public DateTime? ReportDate { get; set; } 
        public int AppointmentId { get; set; }

        public int TestResValue { get; set; }
        public int? ReportId { get; set; }
        public int? LabTestId { get; set; }
    }
}
