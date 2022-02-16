﻿using ClinicalManagementSystemNirvana.Models;
using ClinicalManagementSystemNirvana.View_Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicalManagementSystemNirvana.Repository
{
    public class MedLabPrescRepo : IMedLabPresc
    {
        private readonly CMSDBContext _context;

        public MedLabPrescRepo(CMSDBContext context)
        {
            _context = context;
        }

        //view prescription details based on view model
        #region view prescription details based on view model
        public async Task<List<PrescriptionsViewModel>> GetPrescription()
        {
            if (_context != null)
            {
                return await (
                    from a in _context.Appointments
                    from p in _context.Patients
                    from s in _context.Staffs
                    where a.DoctorId == s.StaffId
                    select new PrescriptionsViewModel
                    {
                        PrescriptionId = a.AppointmentId,
                        PrescriptionDate = a.DateOfAppointment,
                        PatientName = p.PatientName,
                        DoctorName = s.StaffName,
                        Medicines = (from pre in _context.MedPrescriptions
                                     join m in _context.Medicines
                                     on pre.PrescriptionId equals m.PresccriptionId
                                     join inv in _context.MedicineInventory
                                     on m.MedInvId equals inv.MedInvId
                                     where p.PatientId == pre.PatientId
                                     select inv.MedicineName).ToList(),
                        LabTests = (from lre in _context.LabReport
                                    join t in _context.Tests
                                    on lre.ReportId equals t.ReportId
                                    join inv in _context.LabTests
                                    on t.LabTestId equals inv.LabTestId
                                    where lre.AppointmentId == a.AppointmentId
                                    select inv.TestName).ToList()
                    }).ToListAsync();
            }
            return null;
        }
        #endregion

        //Prescribe Medicines
        #region Prescribe Medicine
        public async Task<int> PrescribeMed(Medicines med)
        {
            if (_context != null)
            {
                await _context.Medicines.AddAsync(med);
                await _context.SaveChangesAsync();
                return med.MedId;
            }
            return 0;
        }
        #endregion

        //Prescribe Labtests
        #region Prescribe Labtests
        public async Task<int> PrescribeLabTests(Tests test)
        {
            if (_context != null)
            {
                await _context.Tests.AddAsync(test);
                await _context.SaveChangesAsync();
                return test.TestId;
            }
            return 0;
        }
        #endregion

        #region Pharmacist Bill

        public async Task<List<PharmacistBillingViewModel>> GetMedBill()
        {
            if (_context != null)
            {
                return await (
                    from a in _context.MedicineBilling
                    join b in _context.Medicines
                    on a.MedId equals b.MedId
                    where a.PrescriptionId == b.PresccriptionId

                    select new PharmacistBillingViewModel
                    {
                        MedBillId = a.MedBillId,
                        PrescriptionId = a.PrescriptionId,
                        MedId = b.MedId,
                        MedPrice = b.MedPrice,
                        MedQty = b.MedQty,
                        MedicinePrice = (int)b.MedPrice
                    }).ToListAsync();
            }
                return null;
        }
            #endregion

    }
}
