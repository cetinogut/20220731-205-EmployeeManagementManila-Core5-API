using Entities.Models;
using System.Collections.Generic;

namespace Contracts
{
    public interface IEmployeeRepository: IRepositoryBase<Employee>
    {
        IEnumerable<Employee> GetAllEmployees();
    }
}
