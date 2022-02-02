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
    public class InventoryController : ControllerBase
    {
        //Data fields
        private readonly IInventory _inventory;

        //Constructor injection
        public InventoryController(IInventory inventory)
        {
            _inventory = inventory;
        }

        #region Get All Medicines and Labtests
        [HttpGet]
        [Route("getallmedicines")]
        public async Task<ActionResult<IEnumerable<MedicineInventory>>> GetAllMedicines()
        {
            return await _inventory.GetAllMedicines();
        }

        [HttpGet]
        [Route("getalllabtests")]
        public async Task<ActionResult<IEnumerable<LabTests>>> GetAllLabTests()
        {
            return await _inventory.GetAllLabTests();
        }
        #endregion

        #region Add Medicines and Labtests
        [HttpPost]
        [Route("medicine")]
        public async Task<IActionResult> AddMedicine([FromBody] MedicineInventory medInv)
        {
            //check validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    var medId = await _inventory.AddMedicine(medInv);
                    if (medId > 0)
                    {
                        return Ok(medId);
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
        [Route("labtest")]
        public async Task<IActionResult> AddLabTests([FromBody] LabTests labInv)
        {
            //check validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    var labId = await _inventory.AddLabTests(labInv);
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
        #endregion

        #region Update Medicine and Labtests
        [HttpPut]
        [Route("medicine")]
        public async Task<IActionResult> UpdateMedicine([FromBody] MedicineInventory medInv)
        {
            //check validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    await _inventory.UpdateMedicine(medInv);
                    return Ok();
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }

        [HttpPut]
        [Route("labtest")]
        public async Task<IActionResult> UpdateLabTests([FromBody] LabTests labInv)
        {
            //check validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    await _inventory.UpdateLabTests(labInv);
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

        #region Find Medicine and LabTests
        [HttpGet("{id}")]
        [Route("medicine")]
        public async Task<ActionResult<MedicineInventory>> GetMedicineId(int id)
        {
            try
            {
                var medc = await _inventory.GetMedicineId(id);
                if (medc == null)
                {
                    return NotFound();
                }
                return medc;
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        [Route("labtest")]
        public async Task<ActionResult<LabTests>> GetLabTestsById(int id)
        {
            try
            {
                var labt = await _inventory.GetLabTestsById(id);
                if (labt == null)
                {
                    return NotFound();
                }
                return labt;
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion

        #region Delete Medicine and Labtests
        [HttpDelete("{id}")]
        [Route("medicine")]
        public async Task<IActionResult> DeleteMedicine(int? id)
        {
            int result = 0;
            if (id == null)
            {
                return BadRequest();
            }
            try
            {
                result = await _inventory.DeleteMedicine(id);
                if (result == 0)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        [Route("labtest")]
        public async Task<IActionResult> DeleteLabTests(int? id)
        {
            int result = 0;
            if (id == null)
            {
                return BadRequest();
            }
            try
            {
                result = await _inventory.DeleteLabTests(id);
                if (result == 0)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion

    }
}
