using System;
using System.Collections.Generic;

namespace ClinicalManagementSystemNirvana.Models
{
    public partial class Appointments
    {
        public Appointments()
        {
            DoctorNotes = new HashSet<DoctorNotes>();
            LabReport = new HashSet<LabReport>();
        }

        public int AppointmentId { get; set; }
        public int TokenNo { get; set; }
        public DateTime DateOfAppointment { get; set; }
        public int? PatientId { get; set; }
        public int? DoctorId { get; set; }
        public int? ReceptionistId { get; set; }

        public virtual Doctors Doctor { get; set; }
        public virtual Patients Patient { get; set; }
        public virtual Staffs Receptionist { get; set; }
        public virtual ICollection<DoctorNotes> DoctorNotes { get; set; }
        public virtual ICollection<LabReport> LabReport { get; set; }
    }
}
