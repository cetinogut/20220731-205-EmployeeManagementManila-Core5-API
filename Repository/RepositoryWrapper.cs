using Contracts;
using Entities;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext _repoContext;
        private IEmployeeRepository _employee;
        private IAccountRepository _account;

        public IEmployeeRepository Employee
        {
            get
            {
                if (_employee == null)
                {
                    _employee = new EmployeeRepository(_repoContext);
                }

                return _employee;
            }
        }

        public IAccountRepository Account
        {
            get
            {
                if (_account == null)
                {
                    _account = new AccountRepository(_repoContext);
                }

                return _account;
            }
        }

        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}

//we are creating properties that will expose the concrete repositories and also we have the Save() method that
//we can use after all the modifications are finished on a certain object.
//This is a good practice because now we can, for example, add two employees, modify two accounts and delete one employee, all in one method,
//and then just call the Save method once. All changes will be applied or if something fails, all changes will be reverted: