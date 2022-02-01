using System;
using System.Collections.Generic;

namespace ClinicalManagementSystemNirvana.Models
{
    public partial class MedicineInventory
    {
        public MedicineInventory()
        {
            Medicines = new HashSet<Medicines>();
        }

        public int MedInvId { get; set; }
        public string MedicineName { get; set; }
        public int NetMedQty { get; set; }
        public int UnitPrice { get; set; }
        public string MedDesc { get; set; }
        public int? AdminId { get; set; }

        public virtual Staffs Admin { get; set; }
        public virtual ICollection<Medicines> Medicines { get; set; }
    }
}
