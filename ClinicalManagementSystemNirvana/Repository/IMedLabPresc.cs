using ClinicalManagementSystemNirvana.Models;
using ClinicalManagementSystemNirvana.View_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicalManagementSystemNirvana.Repository
{
    public interface IMedLabPresc
    {
        //For Viewing Full Prescription
        Task<List<PrescriptionsViewModel>> GetPrescription();

        //For Prescribing Labtests
        Task<int> PrescribeLabTests(Tests test);

        //For Prescribing Medicines
        Task<int> PrescribeMed(Medicines med);

        Task<List<PharmacistBillingViewModel>> GetMedBill();

    }
}
