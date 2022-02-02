using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicalManagementSystemNirvana.View_Model
{
    public class StaffViewModel
    {
        public int StaffId { get; set; }
        public string StaffName { get; set; }
        public string StaffIsActive { get; set; }
        public string StaffAddr { get; set; }
        public DateTime? StaffDob { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public int? RoleId { get; set; }
        public string RoleName { get; set; }
    }
}
