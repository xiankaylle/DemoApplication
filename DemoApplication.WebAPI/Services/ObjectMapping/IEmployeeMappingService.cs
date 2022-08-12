using DemoApplication.WebAPI.Models;
using DemoApplication.WebAPI.Transports;

namespace DemoApplication.WebAPI.Services.ObjectMapping
{
    public interface IEmployeeMappingService
    {
        Employee MapToEmployee(EmployeeTransport transport);
        EmployeeTransport MapToEmployee(Employee entity);
    }
}
