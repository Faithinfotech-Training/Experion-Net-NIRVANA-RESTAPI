using System;
using System.Collections.Generic;

namespace ClinicalManagementSystemNirvana.Models
{
    public partial class Doctors
    {
        public Doctors()
        {
            Appointments = new HashSet<Appointments>();
            DoctorNotes = new HashSet<DoctorNotes>();
            MedPrescriptions = new HashSet<MedPrescriptions>();
        }

        public int DoctorId { get; set; }
        public string Specialization { get; set; }
        public int? StaffId { get; set; }

        public virtual Staffs Staff { get; set; }
        public virtual ICollection<Appointments> Appointments { get; set; }
        public virtual ICollection<DoctorNotes> DoctorNotes { get; set; }
        public virtual ICollection<MedPrescriptions> MedPrescriptions { get; set; }
    }
}
