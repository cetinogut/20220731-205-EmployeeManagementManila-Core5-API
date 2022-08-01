using AutoMapper;
using Contracts;
using Entities.DTOs;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace EmployeeManagementManila.Controllers
{
    [Route("api/employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;
        public EmployeeController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAllOwners()
        {
            try
            {
                var employees = _repository.Employee.GetAllEmployees();
                _logger.LogInformation($"Returned all employees from database.");

                var employeesResult = _mapper.Map<IEnumerable<EmployeeDTO>>(employees);

                return Ok(employeesResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllEmployees action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}" , Name = "EmployeeById")] //we are setting the name for the action. This name will come in handy in the action method for creating a new owner.
        public IActionResult GetEmployeeById(Guid id)
        {
            try
            {
                var employee = _repository.Employee.GetEmployeeById(id);

                if (employee is null)
                {
                    _logger.LogError($"employee with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInformation($"Returned employee with id: {id}");

                    var employeeResult = _mapper.Map<EmployeeDTO>(employee);
                    return Ok(employeeResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetEmployeeById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}/account")]
        public IActionResult GetEmployeeWithDetails(Guid id)
        {
            try
            {
                var employee = _repository.Employee.GetEmployeeWithDetails(id);

                if (employee == null)
                {
                    _logger.LogError($"Employee with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInformation($"Returned owner with details for id: {id}");

                    var employeeResult = _mapper.Map<EmployeeDTO>(employee);
                    return Ok(employeeResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetEmployeeWithDetails action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult CreateEmployee([FromBody] EmployeeForCreationDTO employee)
        {
            try
            {
                if (employee is null)
                {
                    _logger.LogError("employee object sent from client is null.");
                    return BadRequest("employee object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid employee object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var employeeEntity = _mapper.Map<Employee>(employee);

                _repository.Employee.CreateEmployee(employeeEntity);
                _repository.Save();

                var createdEmployee = _mapper.Map<EmployeeDTO>(employeeEntity);

                return CreatedAtRoute("EmployeeById", new { id = createdEmployee.Id }, createdEmployee);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateEmployee action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEmployee(Guid id, [FromBody] EmployeeForUpdateDTO employee)
        {
            try
            {
                if (employee is null)
                {
                    _logger.LogError("employee object sent from client is null.");
                    return BadRequest("employee object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid employee object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var employeeEntity = _repository.Employee.GetEmployeeById(id);
                if (employeeEntity is null)
                {
                    _logger.LogError($"employee with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                _mapper.Map(employee, employeeEntity);
                _repository.Employee.UpdateEmployee(employeeEntity);
                _repository.Save();
                return NoContent();
                
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateEmployee action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
