using ClinicalManagementSystemNirvana.Models;
using ClinicalManagementSystemNirvana.View_Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicalManagementSystemNirvana.Repository
{
    public class AppointmentRepository:IAppointmentRepository
    {
        //data fields
        private readonly CMSDBContext _context;

        //default constructor
        //constructor based dependency injection
        public AppointmentRepository(CMSDBContext context)
        {
            _context = context;
        }
        #region get all Appointments
        public async Task<List<Appointments>> GetAllAppointments()
        {
            if (_context != null)
            {
                return await _context.Appointments.ToListAsync();
            }
            return null;

        }

      
        #endregion

        # region GetDoctorAndAppointments
        public async Task<List<Appointmentviewmodel>> GetAllDoctorAndAppointments()
        {
            if (_context != null)
            //linq
            {    
                return await (from a in _context.Appointments
                              from d in _context.Doctors
                              from p in _context.Patients
                              where a.DoctorId == d.DoctorId
                              select new Appointmentviewmodel
                              {
                                  AppointmentId = a.AppointmentId,
                                  TokenNo = a.TokenNo,
                                  DateOfAppointment = a.DateOfAppointment,
                                  DoctorId = d.DoctorId,
                                  PatientId=p.PatientId,
                                  PatientName=p.PatientName
                                 

                              }
                             ).ToListAsync();
            }
            return null;
        }
        #endregion

       



    }
}
