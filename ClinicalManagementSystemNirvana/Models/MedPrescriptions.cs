using System;
using System.Collections.Generic;

namespace ClinicalManagementSystemNirvana.Models
{
    public partial class MedPrescriptions
    {
        public MedPrescriptions()
        {
            MedicineBilling = new HashSet<MedicineBilling>();
            Medicines = new HashSet<Medicines>();
        }

        public int PrescriptionId { get; set; }
        public DateTime? PrescriptionDate { get; set; }
        public int? AppointmentId { get; set; }

        public virtual Appointments Appointment { get; set; }
        public virtual ICollection<MedicineBilling> MedicineBilling { get; set; }
        public virtual ICollection<Medicines> Medicines { get; set; }
    }
}
