using ClinicalManagementSystemNirvana.Models;
using ClinicalManagementSystemNirvana.Repository;
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

    }
}
