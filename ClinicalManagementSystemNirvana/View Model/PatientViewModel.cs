using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicalManagementSystemNirvana.View_Model
{
    public class PatientViewModel
    {
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public string PatientGender { get; set; }
        public string PatientPhoneNo { get; set; }
        public int PrescriptionId { get; set; }
    }
}
