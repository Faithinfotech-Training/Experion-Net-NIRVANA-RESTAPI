using System;
using System.Collections.Generic;

namespace ClinicalManagementSystemNirvana.Models
{
    public partial class Staffs
    {
        public Staffs()
        {
            Appointments = new HashSet<Appointments>();
            Doctors = new HashSet<Doctors>();
            MedicineInventory = new HashSet<MedicineInventory>();
        }

        public int StaffId { get; set; }
        public string StaffName { get; set; }
        public string StaffIsActive { get; set; }
        public string StaffAddr { get; set; }
        public DateTime? StaffDob { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public string BloodGroup { get; set; }
        public string StaffPassword { get; set; }
        public int? RoleId { get; set; }

        public virtual Roles Role { get; set; }
        public virtual ICollection<Appointments> Appointments { get; set; }
        public virtual ICollection<Doctors> Doctors { get; set; }
        public virtual ICollection<MedicineInventory> MedicineInventory { get; set; }
    }
}
