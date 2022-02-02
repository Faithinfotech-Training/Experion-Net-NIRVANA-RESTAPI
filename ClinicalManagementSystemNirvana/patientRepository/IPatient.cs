using ClinicalManagementSystemNirvana.Models;
using ClinicalManagementSystemNirvana.View_Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicalManagementSystemNirvana.Repository
{
    public interface IPatient
    {
        Task<List<Patients>> GetAllPatient();
        //Add Patient
        Task<int> AddPatient(Patients patients);
        //update Patient
        Task UpdatePatient(Patients patients);
        ////delete a Patient
        Task<int> DeletePatient(int? id);
        //find a client with id
        Task<ActionResult<Patients>> GetPatientById(int? id);
        //viewmodel appointment
        Task<List<Appointmentviewmodel>> GetAllAppointment();
        //viewmodel medpres
        Task<List<PrescriptionsViewModel>> GetAllPrescription();

    }
}
