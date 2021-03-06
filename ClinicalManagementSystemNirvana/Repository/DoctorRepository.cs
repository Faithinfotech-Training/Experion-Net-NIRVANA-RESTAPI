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
    public class DoctorRepository : IDoctorRepository
    {
        //data fields
        private readonly CMSDBContext _context;

        //default constructor
        //constructor based dependency injection
        public DoctorRepository(CMSDBContext context)
        {
            _context = context;
        }


        #region GetAllDoctorAndTokens

        public async Task<List<DoctorViewModel>> GetAllDoctorAndTokens(int id)
        {

            if (_context != null)
            //linq
            {
                return await (from a in _context.Appointments
                              from d in _context.Doctors
                              from p in _context.Patients
                              from s in _context.Staffs

                              where s.StaffId == id && s.StaffId==d.StaffId && a.DoctorId == d.DoctorId && p.PatientId == a.PatientId && a.DateOfAppointment==DateTime.Today
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

        #region GetAppointment by ID 

        public async Task<List<DoctorViewModel>> GetAppbyId(int id)
        {

            if (_context != null)
            //linq
            {
                return await (from a in _context.Appointments
                              from d in _context.Doctors
                              from p in _context.Patients
                              from s in _context.Staffs

                              where a.DoctorId == d.DoctorId && d.StaffId == s.StaffId && p.PatientId == a.PatientId && a.AppointmentId == id
                              select new DoctorViewModel
                              {
                                  AppointmentId = a.AppointmentId,
                                  TokenNo = a.TokenNo,
                                  DateOfAppointment = a.DateOfAppointment,
                                  DoctorId = d.DoctorId,
                                  PatientId = a.PatientId,
                                  PatientName = p.PatientName,
                                  DoctorName = s.StaffName
                              }
                             ).ToListAsync();
            }
            return null;

        }

        #endregion

        #region DoctorList
        public async Task<List<DoctorListViewModel>> GetDoctorList()
        {
            if (_context != null)
            //linq
            {
                return await (from s in _context.Staffs
                              from d in _context.Doctors
                             
                              where s.StaffId == d.StaffId
                              select new DoctorListViewModel
                              {
                                
                               DoctorId = d.DoctorId,
                               DoctorName=s.StaffName
                                  

                              }
                             ).ToListAsync();
            }
            return null;

            #endregion
        }
    }

}
    
