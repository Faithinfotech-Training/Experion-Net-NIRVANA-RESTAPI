using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicalManagementSystemNirvana.View_Model
{
    public class PharmacistBillingViewModel
    {
        public int MedBillId { get; set; }
        public DateTime? BillDate { get; set; }
        public int? MedPrice { get; set; }
        public int? PrescriptionId { get; set; }
        public int? MedId { get; set; }
        public int? MedQty { get; set; }
        public int? PatientId { get; set; }
        public int? DoctorId { get; set; }
        public int MedicinePrice { get; set; }
        public int GrandTotal { get; set; }
    }
}
