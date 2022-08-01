using Contracts;
using Entities;
using Entities.Models;
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
    }
}