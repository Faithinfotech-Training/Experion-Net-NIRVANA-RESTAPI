﻿using ClinicalManagementSystemNirvana.Models;
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

        //labtest put
        Task UpdateLabTest(Tests tests);

        //Get Test by Id
        Task<ActionResult<Tests>> GetTestById(int id);

        //add labreport
        Task<int> AddLabReport(Tests test);

        //update Labreport 
        Task UpdateLabReport(Tests tests);


        Task<List<LabReportView>> labReport();

    }
}
