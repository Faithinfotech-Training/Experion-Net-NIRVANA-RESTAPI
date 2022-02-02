using ClinicalManagementSystemNirvana.View_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicalManagementSystemNirvana.Repository
{
    interface IPatientRepository
    {
        Task<List<PatientViewModel>> GetPatientAndPrescription();
    }
}
