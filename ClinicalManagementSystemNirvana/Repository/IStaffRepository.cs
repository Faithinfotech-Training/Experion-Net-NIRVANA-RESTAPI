using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicalManagementSystemNirvana.Models;
using ClinicalManagementSystemNirvana.View_Model;
using Microsoft.AspNetCore.Mvc;

namespace ClinicalManagementSystemNirvana.Repository
{
    public interface IStaffRepository
    {
        //Get All Staff  ----SELECT ----RETRIEVE
        // All data should be 
        Task<List<Staffs>> GetAllstaff(); //ASynchronous

        //Add an employee ----INSERT ----CREATE
        Task<int> AddStaff(Staffs staffs);

        //update an Employee ----UPDATE ---UPDATE
        Task UpdateStaff(Staffs staffs);

        //Find Employee
        Task<ActionResult<Staffs>> GetStaffId(int id);

        //Delete an Employee
        Task<int> DeleteStaff(int? id);

        //Search staff using UserName and Password
        Task<IEnumerable<Staffs>> GetStaffByNameandPassword(string name, string password);

        //Get all Post ---ViewModel
        Task<List<StaffViewModel>> GetAllStaff();
    }
}
