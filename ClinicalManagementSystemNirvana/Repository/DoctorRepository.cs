using ClinicalManagementSystemNirvana.Models;
using ClinicalManagementSystemNirvana.View_Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicalManagementSystemNirvana.Repository
{
    public class DoctorRepository:IDoctorRepository
    {
        //data fields
        private readonly CMSDBContext _context;

        //default constructor
        //constructor based dependency injection
        public DoctorRepository(CMSDBContext context)
        {
            _context = context;
        }
       


        

        #region list doctor view model
      
        public async Task<List<DoctorViewModel>> GetAllDoctorAndTokens( int id)
        {

            if (_context != null)
            //linq
            {
                return await(from a in _context.Appointments
                             from d in _context.Doctors
                             from p in _context.Patients

                             where a.DoctorId == d.DoctorId && p.PatientId == a.PatientId && d.DoctorId==id
                             select new DoctorViewModel
                             {
                                 AppointmentId = a.AppointmentId,
                                 TokenNo = a.TokenNo,
                                 DateOfAppointment = a.DateOfAppointment,
                                 DoctorId = d.DoctorId,
                                 PatientId = a.PatientId,
                                 PatientName = p.PatientName
                             }
                             ).ToListAsync();
            }
            return null;

        }

        #endregion



    }
}
