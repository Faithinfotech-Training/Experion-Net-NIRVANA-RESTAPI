using System;
using System.Collections.Generic;

namespace ClinicalManagementSystemNirvana.Models
{
    public partial class LabReport
    {
        public LabReport()
        {
            Tests = new HashSet<Tests>();
        }

        public int ReportId { get; set; }
        public DateTime? ReportDate { get; set; }
        public int? AppointmentId { get; set; }

        public virtual Appointments Appointment { get; set; }
        public virtual ICollection<Tests> Tests { get; set; }
    }
}
