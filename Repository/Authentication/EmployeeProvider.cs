using LMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Data
{
    public class EmployeeProvider : IEmployeeProvider
    {
        private readonly Lms3Context _db;

        public EmployeeProvider(Lms3Context db)
        {
            _db = db;
        }

        public EmployeeCredential GetEmployeeDetail(EmployeeViewModel login)
        {
            //return users.SingleOrDefault(x => x.EmployeeId == login.Username && x.EmployeePassword == login.Password);
            return _db.EmployeeCredentials.SingleOrDefault(x => x.EmployeeEmail == login.Username && x.EmployeePassword == login.Password );
        }

        public Boolean RegisterEmployee(EmployeeMaster e)
        {
            try
            {
                //_db.EmployeeCredentials.Add(e);
                //_db.SaveChanges();
                _db.EmployeeMasters.Add(e);
                _db.SaveChanges();
                return true;
            } 
            catch
            {
                return false;
            }
        }

        public List<ItemMaster> GetItemDetails(String id)
        {
            try
            {
                var query1 = from item in _db.ItemMasters
                              join issue in _db.EmployeeIssueDetails
                              on item.ItemId equals issue.ItemId
                              where issue.EmployeeId.ToString() == id
                              select item;

                List<ItemMaster> _items = query1.ToList();
                return _items;
            }
            catch
            {
                return new List<ItemMaster>();
            }
        }
        public async Task RegisterEmployeeCredential(EmployeeCredential employeeCredential)
        {
            await _db.EmployeeCredentials.AddAsync(employeeCredential);
            await _db.SaveChangesAsync();
        }

        public async Task<EmployeeCredential> GetEmployeeByIdAsync(string employeeId)
        {
            Guid convEmployeeId;
            Guid.TryParse(employeeId, out convEmployeeId);
            return await _db.EmployeeCredentials.FindAsync(convEmployeeId);
        }
    }
}