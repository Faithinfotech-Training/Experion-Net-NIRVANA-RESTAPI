using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicalManagementSystemNirvana.View_Model
{
    public class AppointmentViewModel
    {
       public int? DoctorId { get; set; }
        public int TokenNo { get; set; }
        public DateTime DateOfAppointment { get; set; }
               
        public int PatientId { get; set; }
        public string PatientName { get; set; }
    public int AppointmentId { get; set; }
    } 

}
