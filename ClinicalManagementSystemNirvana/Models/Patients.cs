using System;
using System.Collections.Generic;

namespace ClinicalManagementSystemNirvana.Models
{
    public partial class Patients
    {
        public Patients()
        {
            Appointments = new HashSet<Appointments>();
        }

        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public DateTime? PatientDob { get; set; }
        public string PatientGender { get; set; }
        public string PatientPhoneNo { get; set; }
        public string BloodGroup { get; set; }

        public virtual ICollection<Appointments> Appointments { get; set; }
    }
}
