using DemoApplication.WebAPI.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoApplication.WebAPI.Models
{
    public class Employee : BaseEntity
    {
        public Employee()
        {
            EmployeeContacts = new HashSet<EmployeeContacts>();
            EmployeeGovernmentNumbers = new HashSet<EmployeeGovernmentNumbers>();
        }
        public EmployeeStatus EmployeeStatus { get; set; }
        public string EmployeeNumber { get; set; }
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }

        public virtual ICollection<EmployeeContacts> EmployeeContacts { get; set; }

        public virtual ICollection<EmployeeGovernmentNumbers> EmployeeGovernmentNumbers { get; set; }

    }
}
