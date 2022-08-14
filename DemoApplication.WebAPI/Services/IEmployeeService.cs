using DemoApplication.WebAPI.Models;
using DemoApplication.WebAPI.Transports;

namespace DemoApplication.WebAPI.Services
{
    public interface IEmployeeService : IBaseDataRepository<EmployeeTransport>
    {
        List<EmployeeTransport> GetBySearchTerm(string searchTerm);
    }
}
