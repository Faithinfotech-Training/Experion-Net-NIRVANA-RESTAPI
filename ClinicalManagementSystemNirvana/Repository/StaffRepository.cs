using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicalManagementSystemNirvana.Models;
using ClinicalManagementSystemNirvana.View_Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClinicalManagementSystemNirvana.Repository
{
    public class StaffRepository : IStaffRepository
    {
        //data fields
        private readonly CMSDBContext _context;

        //default constructor 
        //constructor based dependency injection
        public StaffRepository(CMSDBContext context)
        {
            _context = context;
        }

        #region AddStaff
        public async Task<int> AddStaff(Staffs staffs)
        {
            if (_context != null)
            {
                await _context.Staffs.AddAsync(staffs);
                await _context.SaveChangesAsync();
                return staffs.StaffId;
            }
            return 0;
        }
        #endregion

        #region Delete staff
        public async Task<int> DeleteStaff(int? id)
        {
            int result = 0;
            if (_context != null)
            {
                var staff = await _context.Staffs.FirstOrDefaultAsync(stff => stff.StaffId == id);

                //check condition
                if (staff != null)
                {
                    _context.Staffs.Remove(staff);

                    //commit the trancsaction
                    result = await _context.SaveChangesAsync();
                }

                return result;
            }
            return result;
        }
        #endregion

        #region Get All Staff
        public async Task<List<Staffs>> GetAllstaff()
        {
            if (_context != null)
            {
                return await _context.Staffs.ToListAsync();
            }
            return null;
        }

        #endregion

        #region Get staff by Id
        public async Task<ActionResult<Staffs>> GetStaffId(int id)
        {
            if (_context != null)
            {
                var staff = await _context.Staffs.FindAsync(id);// concentrating on primary key
                return staff;
            }
            return null;
        }
        #endregion

        #region Update Staff
        public async Task UpdateStaff(Staffs staffs)
        {

            if (_context != null)
            {
                _context.Entry(staffs).State = EntityState.Modified;
                _context.Staffs.Update(staffs);
                await _context.SaveChangesAsync(); //Commit the transaction

            }
        }
        #endregion

        #region Get staff by username and password
        //public async Task<IEnumerable<Staffs>> GetStaffByNameandPassword(string name, string password)
        //{
        //    IQueryable<Staffs> result = _context.Staffs;
        //    if (!string.IsNullOrEmpty(name))
        //    {
        //        result = result.Where(e => e.StaffName.Contains(name));
        //    }

        //    if (!string.IsNullOrEmpty(password))
        //    {
        //        result = result.Where(e => e.StaffPassword.Contains(password));
        //    }
        //    return await result.ToListAsync();
        //}
       

        public async Task<Staffs> GetStaffByUsernamePassword(string un, string pw)
        {
            return await (
                from i in _context.Staffs where i.StaffName == un && i.StaffPassword == pw select i
                ).FirstOrDefaultAsync();
        }


        #endregion

        #region Get Staff ViewModel
        public async Task<List<StaffViewModel>> GetAllStaff()
        {
            if (_context != null)
            {
                //LINQ
                //join post and category
                return await(from p in _context.Staffs
                             from c in _context.Roles
                             where p.RoleId == c.RoleId
                             select new StaffViewModel
                             {
                                 StaffId = p.StaffId,
                                 StaffName = p.StaffName,
                                 StaffIsActive = p.StaffIsActive,
                                 StaffAddr = p.StaffAddr,
                                 StaffDob = p.StaffDob,
                                 Gender = p.Gender,
                                 Phone = p.Phone,
                                 RoleId = c.RoleId,
                                 RoleName = c.RoleName

                             }).ToListAsync();
            }
            return null;
        }
        #endregion
    }
}
