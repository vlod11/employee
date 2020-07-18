using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Read;
using Requests;

namespace Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<EmployeeDto> AddEmployeeAsync(EmployeeAddRequest employeeAddRequest);
        Task<IEnumerable<EmployeeDto>> GetAllEmployeesAsync();
    }
}