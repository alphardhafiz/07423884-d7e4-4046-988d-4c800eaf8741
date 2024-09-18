using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Employee;
using api.Helpers;
using api.Models;

namespace api.Interface
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetAllAsync(QueryObject query);
        Task<Employee?> GetByIdAsync(int id);
        Task<Employee> CreateAsync(Employee employeeModel);
        Task<List<Employee>> UpdateAllAsync(List<UpdateEmployeeRequestDto> updatedEmployees);
        Task<Employee?> DeleteAsync(int id);
    }
}