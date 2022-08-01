using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return FindAll()
                .OrderBy(emp => emp.LastName)
                .ToList();
        }

        public Employee GetEmployeeById(Guid employeeId)
        {
            return FindByCondition(employee => employee.Id.Equals(employeeId))
                    .FirstOrDefault();
        }

        public Employee GetEmployeeWithDetails(Guid ownerId)
        {
            return FindByCondition(employee => employee.Id.Equals(ownerId))
                .Include(acc => acc.Accounts)
                .FirstOrDefault();
        }
    }
}