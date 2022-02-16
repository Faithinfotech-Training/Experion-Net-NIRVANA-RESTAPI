using System;
using System.Collections.Generic;

namespace ClinicalManagementSystemNirvana.Models
{
    public partial class DoctorNotes
    {
        public int DoctorNotesId { get; set; }
        public string Notes { get; set; }
        public int? DoctorId { get; set; }
        public int? AppointmentId { get; set; }

        public virtual Appointments Appointment { get; set; }
        public virtual Doctors Doctor { get; set; }
    }
}
