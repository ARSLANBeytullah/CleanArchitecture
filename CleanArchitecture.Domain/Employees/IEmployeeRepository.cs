using GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Employees
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        Task<Employee?> GetByIdAsync(Guid id);
        Task<IEnumerable<Employee>> GetAllAsync();
        Task AddAsync(Employee employee);
        Task UpdateAsync(Employee employee);
        Task DeleteAsync(Guid id);
    }
}
