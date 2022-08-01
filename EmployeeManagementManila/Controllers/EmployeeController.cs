using AutoMapper;
using Contracts;
using Entities.DTOs;
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
    }
}
