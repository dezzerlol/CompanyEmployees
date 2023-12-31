using Contracts;
using Entities.Models;

namespace Repository;

public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
{
    public EmployeeRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public IEnumerable<Employee> GetEmployees(Guid companyId, bool trackChanges)
    {
        return FindByCondition(emp => emp.CompanyId.Equals(companyId), trackChanges)
            .OrderBy(e => e.Name).ToList();
    }

    public Employee GetEmployee(Guid companyId, Guid id, bool trackChanges)
    {
        return FindByCondition(emp => emp.CompanyId.Equals(companyId) && emp.Id.Equals(id), trackChanges)
            .SingleOrDefault();
    }
}