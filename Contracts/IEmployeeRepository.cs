using Entities.Models;
using System;
using System.Collections.Generic;

namespace Contracts
{
    public interface IEmployeeRepository: IRepositoryBase<Employee>
    {
        IEnumerable<Employee> GetAllEmployees();

        Employee GetEmployeeById(Guid employeeId);
        Employee GetEmployeeWithDetails(Guid employeeId);
    }
}
