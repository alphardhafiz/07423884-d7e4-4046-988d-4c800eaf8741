using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Employee;
using api.Helpers;
using api.Interface;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace api.Controllers
{
    [Route("api/employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IEmployeeRepository _employeeRepo;

        public EmployeeController(ApplicationDBContext context, IEmployeeRepository employeeRepo)
        {
            _context = context;
            _employeeRepo = employeeRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] QueryObject query)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var employee = await _employeeRepo.GetAllAsync(query);

            var employeeDto = employee.Select(s => s.ToEmployeeDto()).ToList();

            return Ok(employeeDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var employee = await _employeeRepo.GetByIdAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee.ToEmployeeDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateEmployeeRequestDto employeeDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var employeeModel = employeeDto.ToEmployeeFromCreateDto();

            await _employeeRepo.CreateAsync(employeeModel);

            return CreatedAtAction(nameof(GetById), new { id = employeeModel.Id }, employeeModel.ToEmployeeDto());
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAll([FromBody] List<UpdateEmployeeRequestDto> updateEmployeeDtos)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Panggil metode repository untuk update
            var updatedEmployees = await _employeeRepo.UpdateAllAsync(updateEmployeeDtos);

            if (updatedEmployees == null || updatedEmployees.Count == 0)
            {
                return NotFound("No employees found to update.");
            }

            // Konversi hasil ke DTO
            var updatedEmployeeDtos = updatedEmployees.Select(e => e.ToEmployeeDto()).ToList();

            return Ok(updatedEmployeeDtos);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            return BadRequest(ModelState);

            var employeeModel = await _employeeRepo.DeleteAsync(id);

            if(employeeModel == null)
            {
                return NotFound();
            }

            return Ok("Employee Deleted");
        }

    }
}