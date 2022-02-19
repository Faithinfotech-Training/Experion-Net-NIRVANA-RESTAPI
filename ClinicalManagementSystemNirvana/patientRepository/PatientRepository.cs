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
    public class PatientRepository : IPatient
    {
        private readonly CMSDBContext _context;

        public PatientRepository(CMSDBContext contaxt)
        {
            _context = contaxt;

        }
        #region addpatient
        public async Task<int> AddPatient(Patients patients)
        {
            if (_context != null)
            {
                await _context.Patients.AddAsync(patients);
                await _context.SaveChangesAsync();
                return patients.PatientId;
            }
            return 0;
        }
        #endregion
        #region delete patient by id
        public async  Task<int> DeletePatient(int? id)
        {
            int result = 0;
            if (_context != null)
            {
                var patient = await _context.Patients.FindAsync(id);
                if (patient != null)
                {
                    _context.Patients.Remove(patient);                   
                    result = await _context.SaveChangesAsync();
                }
                return result;
            }
            return 0;
        }
        #endregion
        #region apviewmodel
        public async  Task<List<Appointmentviewmodel>> GetAllAppointment()
        {
            if (_context != null)
            {               
                //join patient  and appointment
                return await (from p in _context.Patients
                              from a in _context.Appointments
                              from d in _context.Staffs
                              from r in _context.Roles
                              where a.PatientId == p.PatientId
                              select new Appointmentviewmodel
                              {
                                  AppointmentId = a.AppointmentId,
                                  TokenNo = a.TokenNo,
                                  DateOfAppointment = a.DateOfAppointment,
                                  PatientId = p.PatientId,
                                  DoctorId = d.RoleId,
                                  ReceptionistId=r.RoleId
                              }
                              ).ToListAsync();
            }
            return null;
        }
        #endregion
        
        #region get all patient
        public async  Task<List<Patients>> GetAllPatient()
        {
            if (_context != null)
                return await _context.Patients.ToListAsync();
            else
                return null;
        }
        #endregion
        #region medviewmodel
        public async Task<List<MedPrescriptionsviewmodel>> GetAllPrescription()
        {
            if (_context != null)
            {
                //join patient  and prescription
                return await (from p in _context.Patients
                              from r in _context.Roles
                              from m in _context.MedPrescriptions
                              from a in _context.Appointments
                              where a.AppointmentId == m.AppointmentId && a.PatientId == p.PatientId
                              select new MedPrescriptionsviewmodel
                              {
                                  PrescriptionId=m.PrescriptionId,
                                  PrescriptionDate=m.PrescriptionDate,
                                  PatientId=p.PatientId,
                                  DoctorId=r.RoleId
                              }
                              ).ToListAsync();
            }
            return null;
        }
        #endregion
        #region get ptient by id
        public async Task<ActionResult<Patients>> GetPatientById(int? id)
        {
            if (_context != null)
            {
                var patient = await _context.Patients.FindAsync(id);
                return patient;
            }

            return null;
        }
        #endregion

        

        #region update patient
        public async Task UpdatePatient(Patients patients)
        {
            if (_context != null)
            {
                _context.Entry(patients).State = EntityState.Modified;
                _context.Patients.Update(patients);
                await _context.SaveChangesAsync();
            }
        }
        
        #endregion
    }
}
