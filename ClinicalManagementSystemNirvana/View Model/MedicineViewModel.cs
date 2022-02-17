using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicalManagementSystemNirvana.View_Model
{
    public class MedicineViewModel
    {
        public int? MedPrice { get; set; }
        public int MedQty { get; set; }

        public string MedicineName { get; set; }
    }
}
