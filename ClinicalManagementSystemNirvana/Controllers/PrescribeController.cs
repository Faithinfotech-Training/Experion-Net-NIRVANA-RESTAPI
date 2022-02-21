using ClinicalManagementSystemNirvana.Models;
using ClinicalManagementSystemNirvana.Repository;
using ClinicalManagementSystemNirvana.View_Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicalManagementSystemNirvana.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrescribeController : ControllerBase
    {
        private readonly IMedLabPresc _medlabRepository;

        //constructor injection
        public PrescribeController(IMedLabPresc medlabRepository)
        {
            _medlabRepository = medlabRepository;
        }

        //All Prescriptions
        #region Get All Prescriptions
        [HttpGet]
        [Route("GetPrescriptions")]
        public async Task<IActionResult> GetPrescription()
        {
            try
            {
                var presc = await _medlabRepository.GetPrescription();
                if (presc == null)
                {
                    //return Ok("Ok Api 1");
                    return NotFound();
                }
                //return Ok("Ok Api 2");
                return Ok(presc);
            }
            catch (Exception)
            {
                //return Ok("Ok Api 3");
                return BadRequest();
            }
        }
        #endregion

        //LAB REPORT
        #region Get LAB REPORT
        [HttpGet]
        [Route("labreport")]
        public async Task<IActionResult> LabReport()
        {
            try
            {
                var presc = await _medlabRepository.labReport();
                if (presc == null)
                {
                    //return Ok("Ok Api 1");
                    return NotFound();
                }
                //return Ok("Ok Api 2");
                return Ok(presc);
            }
            catch (Exception)
            {
                //return Ok("Ok Api 3");
                return BadRequest();
            }
        }
        #endregion

        #region Pharmacy Billing
        [HttpGet]
        [Route("GetMedBill")]
        public async Task<IActionResult> GetPharmacyBilling()
        {
            try
            {
                var presc = await _medlabRepository.GetMedBill();
                if (presc == null)
                {
                    //return Ok("Ok Api 1");
                    return NotFound();
                }
                //return Ok("Ok Api 2");
                return Ok(presc);
            }
            catch (Exception)
            {
                //return Ok("Ok Api 3");
                return BadRequest();
            }
        }
        #endregion

        #region update lab Test
        [HttpPut]
        public async Task<IActionResult> UpdateLabTest([FromBody] Tests tests)
        {
            //check validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    await _medlabRepository.UpdateLabTest(tests);
                    return Ok();
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
        #endregion

        #region Find a LabTest
        [HttpGet("{id}")]
        public async Task<ActionResult<Tests>> GetLabTestById(int id)
        {
            try
            {
                var employee = await _medlabRepository.GetTestById(id);
                if (employee == null)
                {
                    return NotFound();
                }
                return employee;
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion

        #region Add LabReport 
        [HttpPost]
        [Route("labreport")]
        public async Task<IActionResult> AddLabReport([FromBody] Tests tests)
        {
            //check validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    var Id = await _medlabRepository.AddLabReport(tests);
                    if (Id > 0)
                    {
                        return Ok(Id);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
        #endregion

        #region UpdateLabReport
        [HttpPut]
        [Route("labreport")]
        public async Task<IActionResult> UpdateLabReport([FromBody] Tests tests)
        {
            //check validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    await _medlabRepository.UpdateLabReport(tests);
                    return Ok();
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
        #endregion

        //get lab report by report id
        #region Get report by report Id

        [HttpGet]
        [Route("labreport/{id}")]
        public async Task<IActionResult> GetLabReportById(int id)
        {
            try
            {
                var report = await _medlabRepository.GetLabReportById(id);

                if (report == null)
                {
                    return NotFound();
                }
                return Ok(report);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion


        #region Update labtest result 
        [HttpPut]
        [Route("result")]
        public async Task<IActionResult> UpdateResult([FromBody] Tests test)
        {
            //check validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    await _medlabRepository.UpdateResult(test);
                    return Ok();
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
        #endregion

        //MAIN MODULES FOR PRESCRIPTION

        #region COMMENTED CODES - USE LATER

        /*//Medicine Prescribe
        [HttpPost]
        [Route("medPrescs")]
        public async Task<IActionResult> MedPresc([FromBody] MedicinePrescriptionView mpv)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var id = await _medlabRepository.MedPresc(mpv);
                    if (id > 0)
                    {
                        return Ok(id);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch(Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }

        //Lab Prescribe
        [HttpPost]
        [Route("labPrescs")]
        public async Task<IActionResult> LabPresc([FromBody] LabPrescriptionView mpv)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var id = await _medlabRepository.LabPresc(mpv);
                    if (id > 0)
                    {
                        return Ok(id);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }*/
        #endregion

        #region NOT WORKING CODES - FOR REUSE

        [HttpPost]
        [Route("labsreport")]
        public async Task<IActionResult> AddLabReport([FromBody] LabReport labInv)
        {
            //check validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    var labId = await _medlabRepository.LabReport(labInv);
                    if (labId > 0)
                    {
                        return Ok(labId);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("medspresc")]
        public async Task<IActionResult> AddMedPrescription([FromBody] MedPrescriptions labInv)
        {
            //check validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    var labId = await _medlabRepository.MedPrescription(labInv);
                    if (labId > 0)
                    {
                        return Ok(labId);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }

        //Medicine Prescribe
        #region Medicine Prescription
        [HttpPost]
        [Route("medicine")]
        public async Task<IActionResult> PrescribeMed([FromBody] Medicines med)
        {
            //check validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    var Id = await _medlabRepository.PrescribeMed(med);
                    if (Id > 0)
                    {
                        return Ok(Id);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
        #endregion

        //LabTest Prescribe
        #region Lab Test Prescription
        [HttpPost]
        [Route("labtest")]
        public async Task<IActionResult> AddCategory([FromBody] Tests test)
        {
            //check validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    var Id = await _medlabRepository.PrescribeLabTests(test);
                    if (Id > 0)
                    {
                        return Ok(Id);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
        #endregion

        #endregion

        #region PRESCRIPTION CODES - WORKING MAIN MODULES

        //Medicine Prescribe WORKING
        [HttpPost]
        [Route("medPresc/{apId}")]
        public async Task<IActionResult> prescribeMed([FromBody] Medicines mpv , int apId)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var id = await _medlabRepository.prescribeMed(mpv,apId);
                    if (id > 0)
                    {
                        return Ok(id);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }

        //Lab Prescribe WORKING
        [HttpPost]
        [Route("labPresc/{apId}")]
        public async Task<IActionResult> prescribeLab([FromBody] Tests mpv, int apId)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var id = await _medlabRepository.prescribeLab(mpv, apId);
                    if (id > 0)
                    {
                        return Ok(id);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }

        //DOCTOR NOTES
        [HttpPost]
        [Route("notes")]
        public async Task<IActionResult> AddDoctorNotes([FromBody] DoctorNotes tests)
        {
            //check validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    var Id = await _medlabRepository.AddDoctorNotes(tests);
                    if (Id > 0)
                    {
                        return Ok(Id);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }

        #endregion
    }
}
