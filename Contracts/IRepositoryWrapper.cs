namespace Contracts
{
    public interface IRepositoryWrapper
    {
        IEmployeeRepository Employee { get; }
        IAccountRepository Account { get; }
        void Save();
    }
}

//Maybe it’s not a problem when we have only two classes, but what if we need logic from 5 different classes or even more.
//Having that in mind, let’s create a wrapper around our repository user classes.
//Then place it into the IOC and finally inject it inside the controller’s constructor.
//Now, with that wrappers instance, we may call any repository class we need.