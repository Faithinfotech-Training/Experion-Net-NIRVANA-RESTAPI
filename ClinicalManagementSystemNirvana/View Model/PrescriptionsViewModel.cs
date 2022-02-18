using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicalManagementSystemNirvana.View_Model
{
    public class PrescriptionsViewModel
    {
        public int PrescriptionId { get; set; }
        public int ReportId { get; set; }
        public DateTime? PrescriptionDate { get; set; }
        public string PatientName { get; set; }
        public string DoctorName { get; set; }
        public List<string> Medicines { get; set; }
        public List<string> LabTests { get; set; }

        public override string ToString()
        {
            return DoctorName;
        }
    }
}
