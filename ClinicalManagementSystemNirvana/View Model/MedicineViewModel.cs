using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicalManagementSystemNirvana.View_Model
{
    public class MedicineViewModel
    {
        public string MedicineName { get; set; }
        public int MedQty { get; set; }
        public int? MedPrice { get; set; }
        public int Total { get; set; }

    }
}
