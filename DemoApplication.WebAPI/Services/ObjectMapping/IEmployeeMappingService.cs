using DemoApplication.WebAPI.Models;
using DemoApplication.WebAPI.Transports;

namespace DemoApplication.WebAPI.Services.ObjectMapping
{
    public interface IEmployeeMappingService
    {
        Employee MapToEmployee(EmployeeTransport transport);
        EmployeeTransport MapToEmployeeTransport(Employee entity);
        List<EmployeeTransport> MapToEmployeeTransport(List<Employee> entities);
    }
}
