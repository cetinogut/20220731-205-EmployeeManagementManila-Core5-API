using Contracts;
using Entities;
using Entities.Models;

namespace Repository
{
    public class OwnerRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public OwnerRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}