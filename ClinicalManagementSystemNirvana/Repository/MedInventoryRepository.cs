using ClinicalManagementSystemNirvana.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicalManagementSystemNirvana.Repository
{
    public class MedInventoryRepository : IMedInventory
    {

        private readonly CMSDBContext _context;

        public MedInventoryRepository(CMSDBContext context)
        {
            _context = context;
        }

        //add medines
        #region AddMedicine
        public async Task<int> AddMedicine(MedicineInventory medInventory)
        {
            if (_context != null)
            {
                await _context.MedicineInventory.AddAsync(medInventory);
                await _context.SaveChangesAsync();
                return medInventory.MedInvId;
            }
            return 0;
        }
        #endregion


        //delete medicines
        #region DeleteMedicine
        public async Task<int> DeleteMedicine(int? id)
        {
            int result = 0;
            if (_context != null)
            {
                var medc = await _context.MedicineInventory.FirstOrDefaultAsync(med => med.MedInvId == id);

                //check condition
                if (medc != null)
                {
                    _context.MedicineInventory.Remove(medc);

                    //commit the trancsaction
                    result = await _context.SaveChangesAsync();
                }

                return result;
            }
            return result;
        }
        #endregion


        //get all medicines
        #region GetAllMedicines
        public async Task<List<MedicineInventory>> GetAllMedicines()
        {
            if (_context != null)
            {
                return await _context.MedicineInventory.ToListAsync();
            }
            return null;

        }

        #endregion


        //get medicines by id
        #region GetMedicineId
        public async Task<ActionResult<MedicineInventory>> GetMedicineId(int id)
        {
            if (_context != null)
            {
                var medc = await _context.MedicineInventory.FindAsync(id);// concentrating on primary key
                return medc;
            }
            return null;
        }
        #endregion


        //update medicines
        #region UpdateMedicine
        public async Task UpdateMedicine(MedicineInventory medInventory)
        {
            if (_context != null)
            {
                _context.Entry(medInventory).State = EntityState.Modified;
                _context.MedicineInventory.Update(medInventory);
                await _context.SaveChangesAsync(); //Commit the transaction
            }
        }
        #endregion
    }
}
