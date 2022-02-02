using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicalManagementSystemNirvana.View_Model
{
    public class MedPrescriptionsviewmodel
    {
        public int PrescriptionId { get; set; }
        public DateTime? PrescriptionDate { get; set; }
        public int? PatientId { get; set; }
        public int? DoctorId { get; set; }
    }
}
