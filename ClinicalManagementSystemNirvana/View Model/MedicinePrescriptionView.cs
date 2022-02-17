using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicalManagementSystemNirvana.View_Model
{
    public class MedicinePrescriptionView
    {
        public DateTime? PrescriptionDate { get; set; }
        public int? PatientId { get; set; }
        public int? DoctorId { get; set; }

        public int? MedPrice { get; set; }
        public int MedQty { get; set; }
        public int? MedDosage { get; set; }
        public int? PresccriptionId { get; set; }
        public int? MedInvId { get; set; }
    }
}
