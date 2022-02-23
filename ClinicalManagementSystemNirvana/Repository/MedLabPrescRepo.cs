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
                    from d in _context.Doctors
                    from lr in _context.LabReport
                    where a.DoctorId == d.DoctorId && d.StaffId == s.StaffId && a.PatientId == p.PatientId 
                    && lr.AppointmentId == a.AppointmentId && a.DateOfAppointment == DateTime.Today
                    select new PrescriptionsViewModel 
                    {
                        PrescriptionId = a.AppointmentId,
                        ReportId = lr.ReportId,
                        PrescriptionDate = a.DateOfAppointment,
                        PatientName = p.PatientName,
                        DoctorName = s.StaffName,
                        Medicines = (from pre in _context.MedPrescriptions
                                     join m in _context.Medicines
                                     on pre.PrescriptionId equals m.PresccriptionId
                                     join inv in _context.MedicineInventory
                                     on m.MedInvId equals inv.MedInvId
                                     where pre.AppointmentId == a.AppointmentId
                                     select inv.MedicineName).ToList(),
                        LabTests = (from lre in _context.LabReport
                                    join t in _context.Tests
                                    on lre.ReportId equals t.ReportId
                                    join inv in _context.LabTests
                                    on t.LabTestId equals inv.LabTestId
                                    where lre.AppointmentId == a.AppointmentId
                                    select inv.TestName).ToList(),
                        Notes = (from n in _context.DoctorNotes
                                where n.AppointmentId == a.AppointmentId
                                select n.Notes).ToList()
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
                    && a.DoctorId == d.DoctorId && d.StaffId == s.StaffId && a.DateOfAppointment == DateTime.Today
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

        //LabReport and Med Prescriptions - For Prescription
        #region Prescribe Labtests and Lab Prescriptions
        public async Task<int> LabReport(LabReport test)
        {
            if (_context != null)
            {
                await _context.LabReport.AddAsync(test);
                await _context.SaveChangesAsync();
                return test.ReportId;
            }
            return 0;
        }

        public async Task<int> MedPrescription(MedPrescriptions test)
        {
            if (_context != null)
            {
                await _context.MedPrescriptions.AddAsync(test);
                await _context.SaveChangesAsync();
                return test.PrescriptionId;
            }
            return 0;
        }
        #endregion



        //get lab report by id
        #region get lab report by id
        public async Task<List<LabReportView>> GetLabReportById(int id)
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
                    && a.DoctorId == d.DoctorId && d.StaffId == s.StaffId && lr.ReportId == id
                    select new LabReportView
                    {
                        ReportId = lr.ReportId,
                        AppointmentId = a.AppointmentId,
                        ReportDate = a.DateOfAppointment,
                        Doctor = s.StaffName,
                        Patient = p.PatientName,
                        BloodGroup = p.BloodGroup,
                        PhnNo = p.PatientPhoneNo,
                        Tests = (from ts in _context.Tests
                                 join lb in _context.LabTests
                                 on ts.LabTestId equals lb.LabTestId
                                 where lr.ReportId == ts.ReportId
                                 select new TestView
                                 {
                                     TestId = ts.TestId,
                                     TestName = lb.TestName,
                                     Result = ts.TestResValue
                                 }).ToList()
                    }).ToListAsync();
            }
            return null;


        }
        #endregion

        //update labtest result
        public async Task UpdateResult(Tests test)
        {

            if (_context != null)
            {
                _context.Entry(test).State = EntityState.Modified;
                _context.Tests.Update(test);
                await _context.SaveChangesAsync(); //Commit the transaction
            }
        }






        #region Pharmacist Bill

        public async Task<List<PharmacistBillingViewModel>> GetMedBill()
        {
            if (_context != null)
            {
                return await (
                    from a in _context.Patients
                    from b in _context.MedPrescriptions
                    
                    from p in _context.Appointments
                    where p.PatientId==a.PatientId && b.AppointmentId == p.AppointmentId && b.PrescriptionDate == DateTime.Today
                    

                    select new PharmacistBillingViewModel
                    {
                        PatientName = a.PatientName,
                        PrescriptionId = b.PrescriptionId,
                        PatientId = p.PatientId,
                        Date = b.PrescriptionDate,
                       
                        DoctorId = p.DoctorId,
                        Medicine = (
                                    from ac in _context.Medicines
     
                                    join ae in _context.MedicineInventory
                                    on ac.MedInvId equals ae.MedInvId
                                    where ac.PresccriptionId == b.PrescriptionId
                                    select new MedicineViewModel
                                    {
                                        MedicineName = ae.MedicineName,
                                        MedPrice = ae.UnitPrice,
                                        MedQty = (int)ac.MedQty,
                                        Total = (int)(ac.MedQty * ae.UnitPrice)
                                    }).ToList()
                       
                    }).ToListAsync();
            }
                return null;
        }
        #endregion

        //Medicine Prescription
        #region Medicine Prescription
        public async Task<int> MedPresc(MedicinePrescriptionView mv)
        {

            DoctorNotes dn = new DoctorNotes();
            dn.Notes = mv.DoctorNotes;
            dn.DoctorId = mv.DoctorId;
            dn.AppointmentId = mv.AppointmentId;

            await _context.DoctorNotes.AddAsync(dn);
            await _context.SaveChangesAsync();

            Medicines ms = new Medicines();
            ms.MedQty = mv.MedQty;
            ms.MedDosage = mv.MedDosage;
            ms.PresccriptionId = mv.PresccriptionId;
            ms.MedInvId = mv.MedInvId;

            await _context.Medicines.AddAsync(ms);
            await _context.SaveChangesAsync();

            return ms.MedId;
        }
        #endregion

        //Lab Prescription
        #region Lab Prescription
        public async Task<int> LabPresc(LabPrescriptionView mv)
        {
            LabReport lr = new LabReport();
            lr.ReportDate = mv.ReportDate;
            lr.AppointmentId = mv.AppointmentId;

            await _context.LabReport.AddAsync(lr);
            await _context.SaveChangesAsync();

            Tests ts = new Tests();
            ts.TestResValue = mv.TestResValue;
            ts.ReportId = lr.ReportId;
            ts.LabTestId = mv.LabTestId;

            await _context.Tests.AddAsync(ts);
            await _context.SaveChangesAsync();

            return ts.TestId;
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

        public async Task<int> prescribeLab(Tests ts , int apId)
        {
            if (_context != null)
            {
                var temp = _context.LabReport.Where(x => x.AppointmentId == apId).FirstOrDefault();
                if (temp == null)
                {
                    LabReport lr = new LabReport();
                    lr.AppointmentId = apId;
                    lr.ReportDate = DateTime.Today;
                    await _context.LabReport.AddAsync(lr);
                    await _context.SaveChangesAsync();
                }
                temp = _context.LabReport.Where(x => x.AppointmentId == apId).FirstOrDefault();
                ts.ReportId = temp.ReportId;
                await _context.Tests.AddAsync(ts);
                await _context.SaveChangesAsync();
                return ts.TestId;
            }
            return 0;
        }

        public async Task<int> prescribeMed(Medicines ms, int apId)
        {
            if (_context != null)
            {
                var temp = _context.MedPrescriptions.Where(x => x.AppointmentId == apId).FirstOrDefault();
                if (temp == null)
                {
                    MedPrescriptions lr = new MedPrescriptions();
                    lr.AppointmentId = apId;
                    lr.PrescriptionDate = DateTime.Today;
                    await _context.MedPrescriptions.AddAsync(lr);
                    await _context.SaveChangesAsync();
                }
                temp = _context.MedPrescriptions.Where(x => x.AppointmentId == apId).FirstOrDefault();
                ms.PresccriptionId = temp.PrescriptionId;
                await _context.Medicines.AddAsync(ms);
                await _context.SaveChangesAsync();
                return ms.MedId;
            }
            return 0;
        }

        public async Task<int> AddDoctorNotes(DoctorNotes test)
        {
            if (_context != null)
            {

                await _context.DoctorNotes.AddAsync(test);
                await _context.SaveChangesAsync();
                return test.DoctorNotesId;
            }
            return 0;
        }

        #region GetMedBillById

        public async Task<List<PharmacistBillingViewModel>> GetMedBillById(int id)
        {
            if (_context != null)
            {
                return await (
                    from a in _context.Patients
                    from b in _context.MedPrescriptions
                    from s in _context.Staffs
                    from d in _context.Doctors
                    from p in _context.Appointments
                    where p.PatientId == a.PatientId && b.AppointmentId == p.AppointmentId 
                    && p.DoctorId == d.DoctorId && d.StaffId == s.StaffId 
                    && b.PrescriptionDate == DateTime.Today


                    select new PharmacistBillingViewModel
                    {
                        PatientName = a.PatientName,
                        PrescriptionId = b.PrescriptionId,
                        PatientId = p.PatientId,
                        Date = b.PrescriptionDate,
                        DoctorName=s.StaffName,
                        DoctorId = p.DoctorId,
                        Medicine = (
                                    from ac in _context.Medicines

                                    join ae in _context.MedicineInventory
                                    on ac.MedInvId equals ae.MedInvId
                                    where ac.PresccriptionId == b.PrescriptionId
                                    select new MedicineViewModel
                                    {
                                        MedicineName = ae.MedicineName,
                                        MedPrice = ae.UnitPrice,
                                        MedQty = (int)ac.MedQty,
                                        Total = (int)(ac.MedQty * ae.UnitPrice)
                                    }).ToList()

                    }).ToListAsync();
            }
            return null;
        }
        #endregion
    }
}
