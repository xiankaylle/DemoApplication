using DemoApplication.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoApplication.WebAPI.DatabaseContext
{
    public interface IApplicationDbContext
    {
        DbSet<Employee> Employee { get; set; }
        DbSet<EmployeeContacts> EmployeeContacts { get; set; }
        DbSet<EmployeeGovernmentNumbers> EmployeeGovernmentNumbers { get; set; }


    }
}
