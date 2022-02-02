using System;
using System.Collections.Generic;

namespace ClinicalManagementSystemNirvana.Models
{
    public partial class LabTests
    {
        public LabTests()
        {
            Tests = new HashSet<Tests>();
        }

        public int LabTestId { get; set; }
        public string TestName { get; set; }
        public decimal TestNormalRange { get; set; }
        public string TestDesc { get; set; }
        public int? TestPrice { get; set; }
        public string TestUnit { get; set; }

        public virtual ICollection<Tests> Tests { get; set; }
    }
}
