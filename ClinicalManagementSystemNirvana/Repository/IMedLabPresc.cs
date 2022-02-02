using ClinicalManagementSystemNirvana.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicalManagementSystemNirvana.Repository
{
    public interface IMedLabPresc
    {
        Task<int> PrescribeLabTests(Tests test);
        Task<int> PrescribeMed(Medicines med);
    }
}
