﻿using EEMS.BusinessLogic.Interfaces;
using EEMS.DataAccess;
using EEMS.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace EEMS.BusinessLogic.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly EEMSDbContext _context;

        public EmployeeService(EEMSDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Employee>> GetAsync()
        {
            return await _context.jobNature.ToListAsync();
        }

        public async Task<Employee> GetAsync(int id)
        {
            return await _context.jobNature.FindAsync(id);
        }

        public async Task<int> AddAsync(Employee employee)
        {
            var added = _context.jobNature.Add(employee);
            await _context.SaveChangesAsync();

            return added.Entity.Id;
        }

        public async Task UpdateAsync(Employee employee)
        {
            _context.jobNature.Update(employee);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var emp = await GetAsync(id);
            if (emp != null)
            {
                _context.jobNature.Remove(emp);
                await _context.SaveChangesAsync();
            }
        }

        // 
    }
}
