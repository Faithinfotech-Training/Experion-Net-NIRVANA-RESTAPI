using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicalManagementSystemNirvana.View_Model
{
    public class PharmacistBillingViewModel
    {
        public int Medicine_Bill_Id { get; set; }
        public DateTime? BillDate { get; set; }
        public int? PrescriptionId { get; set; }
        public int? PatientId { get; set; }
        public int? DoctorId { get; set; }
        public List<MedicineViewModel> Medicine { get; set; }
        public int GrandTotal { get; set; }
    }
}
