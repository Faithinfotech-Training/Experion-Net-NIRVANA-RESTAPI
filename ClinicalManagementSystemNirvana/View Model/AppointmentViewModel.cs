using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicalManagementSystemNirvana.View_Model
{
    public class Appointmentviewmodel
    {
       public DateTime DateOfAppointment { get; set; }
        public int AppointmentId { get; set; } 
        public int TokenNo { get; set; }
        public int? DoctorId { get; set; }
        public string DoctorName { get; set; }
        public string PatientName { get; set; }
        public int? PatientId { get; set; }
        
        public int? ReceptionistId { get; set; }
       
    }
}
