using System;
using System.Collections.Generic;

namespace ClinicalManagementSystemNirvana.Models
{
    public partial class Medicines
    {
        public Medicines()
        {
            MedicineBilling = new HashSet<MedicineBilling>();
        }

        public int MedId { get; set; }
        public int? MedPrice { get; set; }
        public int? MedQty { get; set; }
        public int? MedDosage { get; set; }
        public int? PresccriptionId { get; set; }
        public int? MedInvId { get; set; }

        public virtual MedicineInventory MedInv { get; set; }
        public virtual MedPrescriptions Presccription { get; set; }
        public virtual ICollection<MedicineBilling> MedicineBilling { get; set; }
    }
}
