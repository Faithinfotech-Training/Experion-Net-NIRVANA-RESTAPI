using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicalManagementSystemNirvana.View_Model
{
    public class Appointmentviewmodel
    {
        public int AppointmentId { get; set; }
        public int TokenNo { get; set; }
        public DateTime DateOfAppointment { get; set; }
        public int? PatientId { get; set; }
        public int? DoctorId { get; set; }
        public int? ReceptionistId { get; set; }
    }
}
