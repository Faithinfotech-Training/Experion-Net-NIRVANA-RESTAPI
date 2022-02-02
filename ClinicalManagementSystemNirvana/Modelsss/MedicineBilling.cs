using System;
using System.Collections.Generic;

namespace ClinicalManagementSystemNirvana.Models
{
    public partial class MedicineBilling
    {
        public int MedBillId { get; set; }
        public DateTime? BillDate { get; set; }
        public int TotalPrice { get; set; }
        public int? PrescriptionId { get; set; }
        public int? MedId { get; set; }

        public virtual Medicines Med { get; set; }
        public virtual MedPrescriptions Prescription { get; set; }
    }
}
