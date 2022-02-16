using ClinicalManagementSystemNirvana.Models;
using ClinicalManagementSystemNirvana.View_Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicalManagementSystemNirvana.Repository
{
     public interface IAppointmentRepository
    {
        //get all post
        Task<List<Appointments>> GetAllAppointments();

        //Join doctorId and Appointments
        Task<List<Appointmentviewmodel>> GetAllDoctorAndAppointments();

       
       




    }
}
