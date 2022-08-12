using DemoApplication.WebAPI.Models;
using DemoApplication.WebAPI.Models.Enums;
using DemoApplication.WebAPI.Transports;

namespace DemoApplication.WebAPI.Services.ObjectMapping
{
    public class EmployeeMapping : IEmployeeMappingService
    {
        /// <summary>
        /// Map Transport To Entity
        /// </summary>
        /// <param name="transport"></param>
        /// <returns></returns>
        public Employee MapToEmployee(EmployeeTransport transport)
        {
            var employeeContacts = transport.EmployeeContacts.Select(x => new EmployeeContacts { 
                 CreatedBy = x.CreatedBy,
                 CreatedOn = x.CreatedOn,
                 IsActive = x.IsActive,
                 IsPrimary  = x.IsPrimary,
                 Type = x.Type,
                 Value = x.Value,
                 UpdatedBy = x.UpdatedBy,
                 UpdatedOn = x.UpdatedOn,
                 EmployeeContactType = (EmployeeContactTypes)x.EmployeeContactType
                 
            }).ToList();

            var employeeEmployeeGovernmentNums = transport.EmployeeGovernmentNumbers.Select(x => new EmployeeGovernmentNumbers
            {
                UpdatedBy = x.UpdatedBy,
                UpdatedOn = x.UpdatedOn,
                CreatedBy = x.CreatedBy,
                CreatedOn = x.CreatedOn,
                Value = x.Value,
                Type = x.Type, 
                GovernmentNumberTypeId = (GovernmentNumberType)x.GovernmentNumberTypeId
            }).ToList();

            var employee = new Employee()
            {
                Id = transport.Id,
                FirstName = transport.FName,
                LastName = transport.LName,
                MiddleName = transport.MName,
                BirthDate = transport.Bdate,
                UpdatedOn = transport.UpdatedOn,
                UpdatedBy = transport.UpdatedBy,
                CreatedBy = transport.CreatedBy,
                CreatedOn = transport.CreatedOn,
                EmployeeNumber = transport.EmpNumber,
                EmployeeStatus = (EmployeeStatus)transport.EmployeeStatus,
                EmployeeContacts = employeeContacts,
                EmployeeGovernmentNumbers = employeeEmployeeGovernmentNums

            };
            return employee;
        }
        /// <summary>
        /// Map Entity To Transport
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public EmployeeTransport MapToEmployee(Employee entity)
        {
            var employee = new EmployeeTransport()
            {
                FName = entity.FirstName,
                LName = entity.LastName,
                Bdate = entity.BirthDate
            };
            return employee;
        }

        public List<EmployeeTransport> MapToEmployeeransport(List<Employee> entities)
        {
            var employeeTranport = new List<EmployeeTransport>();
            entities.ForEach(e =>
            {
                employeeTranport.Add(new EmployeeTransport
                {
                    Id = e.Id,
                    FName = e.FirstName,
                    LName = e.LastName,
                    MName = e.MiddleName,
                    Bdate = e.BirthDate,
                    EmpNumber = e.EmployeeNumber,
                    CreatedBy = e.CreatedBy,
                    CreatedOn = e.CreatedOn,
                    UpdatedBy = e.UpdatedBy,
                    UpdatedOn = e.UpdatedOn,
                });
            });

            return employeeTranport;
        }
    }
}
