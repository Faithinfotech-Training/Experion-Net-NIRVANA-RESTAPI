using System;
using System.Collections.Generic;

namespace ClinicalManagementSystemNirvana.Models
{
    public partial class Tests
    {
        public int TestId { get; set; }
        public int? ReportId { get; set; }
        public int? LabTestId { get; set; }

        public virtual LabTests LabTest { get; set; }
        public virtual LabReport Report { get; set; }
    }
}
