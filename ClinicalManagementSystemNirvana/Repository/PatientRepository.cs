using ClinicalManagementSystemNirvana.Models;
using ClinicalManagementSystemNirvana.View_Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicalManagementSystemNirvana.Repository
{
    public class PatientRepository:IPatientRepository
    {
        //data fields
        private readonly CMSDBContext _context;

        //default constructor
        //constructor based dependency injection
        public PatientRepository(CMSDBContext context)
        {
            _context = context;
        }
        #region get custom post table using postview model

        public async Task<List<PatientViewModel>> GetPatientAndPrescription()
        {

               
        if (_context != null)
            //linq
            {    //join the patients and prescriptionId
                return await (from p in _context.Patients
                              from pr in _context.MedPrescriptions
                              where p.PatientId == pr.PatientId
                              select new PatientViewModel
                              {
                                  PatientId = p.PatientId,
                                  PatientName = p.PatientName,
                                  PatientGender = p.PatientGender,
                                  PatientPhoneNo = p.PatientPhoneNo,
                                  PrescriptionId = pr.PrescriptionId,
                                 

                              }
                             ).ToListAsync();
            }
            return null;
        }

      
        #endregion
    }
}
