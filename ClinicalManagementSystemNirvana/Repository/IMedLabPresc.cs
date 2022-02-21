using ClinicalManagementSystemNirvana.Models;
using ClinicalManagementSystemNirvana.View_Model;
using Microsoft.AspNetCore.Mvc;
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

        Task<List<PharmacistBillingViewModel>> GetMedBillById(int id);

        //labtest put
        Task UpdateLabTest(Tests tests);

        //Get Test by Id
        Task<ActionResult<Tests>> GetTestById(int id);

        //add labreport
        Task<int> AddLabReport(Tests test);

        //update Labreport 
        Task UpdateLabReport(Tests tests);


        Task<List<LabReportView>> labReport();


        Task<List<LabReportView>> GetLabReportById(int id);

        //update test result
        Task UpdateResult(Tests test);

        //MEDICINE PRESCRIPTION
        Task<int> MedPresc(MedicinePrescriptionView mv);
        Task<int> MedPrescription(MedPrescriptions test);
        Task<int> prescribeMed(Medicines ms, int apId); //WORKING


        //LAB PRESCRIPTION
        Task<int> LabPresc(LabPrescriptionView mv);
        Task<int> LabReport(LabReport test);
        Task<int> prescribeLab(Tests ts, int apId); //WORKING

        //DOCTOR NOTES
        Task<int> AddDoctorNotes(DoctorNotes test);
    }
}
