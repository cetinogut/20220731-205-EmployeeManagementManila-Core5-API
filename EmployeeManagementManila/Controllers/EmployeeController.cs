using Contracts;
using Microsoft.AspNetCore.Mvc;
using System;

namespace EmployeeManagementManila.Controllers
{
    [Route("api/employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        public EmployeeController(ILoggerManager logger, IRepositoryWrapper repository)
        {
            _logger = logger;
            _repository = repository;
        }
        [HttpGet]
        public IActionResult GetAllOwners()
        {
            try
            {
                var employees = _repository.Employee.GetAllEmployees();
                _logger.LogInformation($"Returned all employees from database.");
                return Ok(employees);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllEmployees action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
