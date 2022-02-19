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
    public class AppointmentRepository:IAppointmentRepository
    {
        //data fields
        private readonly CMSDBContext _context;

        public AppointmentRepository(CMSDBContext context)
        {
            _context = context;
        }

        public async Task<int> AddAppointment(Appointments appointments)
        {
            if (_context != null)
            {
                await _context.Appointments.AddAsync(appointments);
                await _context.SaveChangesAsync();
                return appointments.AppointmentId;
            }
            return 0;
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
                              from s in _context.Staffs 
                              where a.DoctorId == d.DoctorId && d.StaffId==s.StaffId  && a.PatientId==p.PatientId
                              select new Appointmentviewmodel 
                              {
                                  AppointmentId = a.AppointmentId,
                                  TokenNo = a.TokenNo,
                                  DateOfAppointment = a.DateOfAppointment,
                                  DoctorId = d.DoctorId,
                                  PatientId=p.PatientId,
                                  PatientName=p.PatientName,
                                  DoctorName=s.StaffName
                                 
                              }
                             ).ToListAsync();
            }
            return null;
        }

        public async Task<ActionResult<Appointments>> GetAppointmentById(int? id)
        {
            if (_context != null)
            {
                var appointment = await _context.Appointments.FindAsync(id);
                return appointment;
            }

            return null;
        }

        public async Task<List<Appointments>> GetAppointments()
        {
            if (_context != null)
            {
                return await _context.Appointments.ToListAsync();
            }
            return null;
        }

        public async Task UpdateApppointment(Appointments appointments)
        {
            if (_context != null)
            {
                _context.Entry(appointments).State = EntityState.Modified;
                _context.Appointments.Update(appointments);
                await _context.SaveChangesAsync();
            }
        }
        #endregion

        







    }
}
