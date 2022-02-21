using ClinicalManagementSystemNirvana.Models;
using ClinicalManagementSystemNirvana.Repository;
using Microsoft.AspNetCore.Authorization;
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
    public class MedInventoryController : ControllerBase
    {
        //Data fields
        private readonly IMedInventory _inventoryRepository;

        //Constructor injection
        public MedInventoryController(IMedInventory inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }

        #region getallmedicines
        [HttpGet]
        [Route("get")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<MedicineInventory>>> GetAllMedicines()
        {
            return await _inventoryRepository.GetAllMedicines();
        }
        #endregion

        
        #region Add Medicines
        [HttpPost]
        [Route("medicine")]
        [Authorize]
        public async Task<IActionResult> AddMedicine([FromBody] MedicineInventory medInventory)
        {
            //check validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    var medId = await _inventoryRepository.AddMedicine(medInventory);
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
        #endregion


        #region Update Medicine 
        [HttpPut]
        [Route("medicine")]
        [Authorize]
        public async Task<IActionResult> UpdateMedicine([FromBody] MedicineInventory medInv)
        {
            //check validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    await _inventoryRepository.UpdateMedicine(medInv);
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


        #region Find Medicine
        [HttpGet("medicine/{id}")]
        [Authorize]
        public async Task<ActionResult<MedicineInventory>> GetMedicineId(int id)
        {
            try
            {
                var medc = await _inventoryRepository.GetMedicineId(id);
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
        #endregion


        #region Delete Medicine
        [HttpDelete("medicine/{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteMedicine(int? id)
        {
            int result = 0;
            if (id == null)
            {
                return BadRequest();
            }
            try
            {
                result = await _inventoryRepository.DeleteMedicine(id);
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
