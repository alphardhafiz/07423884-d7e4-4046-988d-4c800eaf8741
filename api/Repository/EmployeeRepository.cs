using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Employee;
using api.Helpers;
using api.Interface;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDBContext _context;
        public EmployeeRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Employee> CreateAsync(Employee employeeModel)
        {
            await _context.Employees.AddAsync(employeeModel);
            await _context.SaveChangesAsync();
            return employeeModel;
        }

        public async Task<Employee?> DeleteAsync(int id)
        {
            var employeeModel = await _context.Employees.FirstOrDefaultAsync(e => e.Id == id);

            if (employeeModel == null)
            {
                return null;
            }

            _context.Employees.Remove(employeeModel);
            await _context.SaveChangesAsync();
            return employeeModel;
        }

        public async Task<List<Employee>> GetAllAsync(QueryObject query)
        {
            var employee = _context.Employees.AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.Search))
            {
                employee = employee.Where(e => e.FirstName.Contains(query.Search) || e.LastName.Contains(query.Search) || e.Position.Contains(query.Search) || e.Phone.Contains(query.Search) || e.Email.Contains(query.Search));
            }

            var skipNumber = (query.PageNumber - 1) * query.PageSize;

            return await employee.Skip(skipNumber).Take(query.PageSize).ToListAsync();
        }

        public async Task<Employee?> GetByIdAsync(int id)
        {
            return await _context.Employees.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<List<Employee>> UpdateAllAsync(List<UpdateEmployeeRequestDto> updatedEmployeesDto)
        {
            var employeeIds = updatedEmployeesDto.Select(e => e.Id).ToList();
            var existingEmployees = await _context.Employees.Where(e => employeeIds.Contains(e.Id)).ToListAsync();

            foreach (var employee in existingEmployees)
            {
                var updatedEmployeeDto = updatedEmployeesDto.First(e => e.Id == employee.Id);

                // Update hanya jika nilai tidak null
                if (!string.IsNullOrWhiteSpace(updatedEmployeeDto.FirstName))
                {
                    employee.FirstName = updatedEmployeeDto.FirstName;
                }

                if (!string.IsNullOrWhiteSpace(updatedEmployeeDto.LastName))
                {
                    employee.LastName = updatedEmployeeDto.LastName;
                }

                if (!string.IsNullOrWhiteSpace(updatedEmployeeDto.Position))
                {
                    employee.Position = updatedEmployeeDto.Position;
                }

                if (!string.IsNullOrWhiteSpace(updatedEmployeeDto.Phone))
                {
                    employee.Phone = updatedEmployeeDto.Phone;
                }

                if (!string.IsNullOrWhiteSpace(updatedEmployeeDto.Email))
                {
                    employee.Email = updatedEmployeeDto.Email;
                }
            }

            _context.Employees.UpdateRange(existingEmployees);
            await _context.SaveChangesAsync();

            return existingEmployees; // Mengembalikan List<Employee> yang diperbarui
        }

    }
}