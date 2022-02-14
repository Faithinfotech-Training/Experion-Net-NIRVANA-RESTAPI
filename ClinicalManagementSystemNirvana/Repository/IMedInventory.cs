using ClinicalManagementSystemNirvana.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicalManagementSystemNirvana.Repository
{
    public interface IMedInventory
    {
        //get all medicines
        Task<List<MedicineInventory>> GetAllMedicines();


        //add medicnes
        Task<int> AddMedicine(MedicineInventory medInventory);

        
        //update medicines
        Task UpdateMedicine(MedicineInventory medInventory);


         //delete medicines
        Task<int> DeleteMedicine(int? id);

        //get medicines by id
        Task<ActionResult<MedicineInventory>> GetMedicineId(int id);

       
    }
}
