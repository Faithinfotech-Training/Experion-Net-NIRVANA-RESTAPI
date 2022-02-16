using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicalManagementSystemNirvana.View_Model
{
    public class LabReportViewModel
    {
        public int ReportId { get; set; }
        public DateTime? ReportDate { get; set; }
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public string PatientGender { get; set; }
        public string PatientPhoneNo { get; set; }
        public string BloodGroup { get; set; }
        public int DoctorId { get; set; }
        public string TestName { get; set; }
        public decimal TestNormalRange { get; set; }
        public string TestDesc { get; set; }
        public int? TestPrice { get; set; }
        public string TestUnit { get; set; }
        public int TestResValue { get; set; }

    }
}
