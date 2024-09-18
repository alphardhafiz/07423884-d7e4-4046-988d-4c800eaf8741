using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Employee;
using api.Models;

namespace api.Mappers
{
    public static class EmployeeMappers
    {
        public static EmployeeDto ToEmployeeDto(this Employee employee)
        {
            return new EmployeeDto
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Position = employee.Position,
                Phone = employee.Phone,
                Email = employee.Email
            };
        }

        public static Employee ToEmployeeFromCreateDto(this CreateEmployeeRequestDto employeeDto)
        {
            return new Employee
            {
                FirstName= employeeDto.FirstName,
                LastName= employeeDto.LastName,
                Position= employeeDto.Position,
                Phone= employeeDto.Phone,
                Email= employeeDto.Email,
            };
        }
    }
}