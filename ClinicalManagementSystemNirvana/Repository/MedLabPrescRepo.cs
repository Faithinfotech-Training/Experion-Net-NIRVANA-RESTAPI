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
                    where a.DoctorId == s.StaffId && a.PatientId == p.PatientId
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

        //view prescription details based on view model
        #region view prescription details based on view model
        public async Task<List<LabReportView>> labReport()
        {
            if (_context != null)
            {
                return await (
                    from a in _context.Appointments
                    from lr in _context.LabReport
                    from p in _context.Patients
                    from s in _context.Staffs
                    from d in _context.Doctors
                    where lr.AppointmentId == a.AppointmentId && a.PatientId == p.PatientId
                    && a.DoctorId == d.DoctorId && d.DoctorId == s.StaffId
                    select new LabReportView
                    {
                        ReportId = lr.ReportId,
                        AppointmentId = a.AppointmentId,
                        ReportDate = a.DateOfAppointment,
                        Doctor = s.StaffName,
                        Patient = p.PatientName,
                        BloodGroup = p.BloodGroup,
                        PhnNo = p.PatientPhoneNo,
                        Tests = (       from ts in _context.Tests
                                        join lb in _context.LabTests
                                        on ts.LabTestId equals lb.LabTestId
                                        where lr.ReportId == ts.ReportId
                                        select new TestView
                                        {
                                            TestName = lb.TestName,
                                            Result = ts.TestResValue
                                        }).ToList()                     
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
                    from b in _context.MedPrescriptions
                    from c in _context.Medicines
                    where a.PrescriptionId == b.PrescriptionId &&
                    a.MedId == c.MedId
                    select new PharmacistBillingViewModel
                    {
                        Medicine_Bill_Id = a.MedBillId,
                        BillDate = a.BillDate,
                        PrescriptionId = a.PrescriptionId,
                        PatientId = b.PatientId,
                        DoctorId = b.DoctorId,
                        Medicine = (
                                    from ac in _context.Medicines
                                    join ab in _context.MedicineBilling
                                    on ac.MedId equals ab.MedId
                                    join ad in _context.MedPrescriptions
                                    on ac.PresccriptionId equals ad.PrescriptionId
                                    join ae in _context.MedicineInventory
                                    on ac.MedInvId equals ae.MedInvId
                                    where ab.PrescriptionId == a.PrescriptionId
                                    select new MedicineViewModel
                                    {
                                        MedicineName = ae.MedicineName,
                                        MedPrice = ac.MedPrice,
                                        MedQty = ac.MedQty
                                    }).ToList(),
                        GrandTotal = (int)(c.MedQty * c.MedPrice)
                    }).ToListAsync();
            }
                return null;
        }
        #endregion

        public async Task UpdateLabTest(Tests tests)
        {
            if (_context != null)
            {
                _context.Entry(tests).State = EntityState.Modified;
                _context.Tests.Update(tests);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<ActionResult<Tests>> GetTestById(int id)
        {
            if (_context != null)
            {
                var employee = await _context.Tests.FindAsync(id);// concentrating on primary key
                return employee;
            }
            return null;
        }

        public async Task<int> AddLabReport(Tests test)
        {
            if (_context != null)
            {
                await _context.Tests.AddAsync(test);
                await _context.SaveChangesAsync();
                return test.TestId;
            }
            return 0;
        }

        public async Task UpdateLabReport(Tests tests)
        {
            if (_context != null)
            {
                _context.Entry(tests).State = EntityState.Modified;
                _context.Tests.Update(tests);
                await _context.SaveChangesAsync();
            }
        }
    }
}
