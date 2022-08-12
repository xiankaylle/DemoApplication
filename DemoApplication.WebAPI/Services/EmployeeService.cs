using DemoApplication.WebAPI.DatabaseContext;
using DemoApplication.WebAPI.Models;
using DemoApplication.WebAPI.Services.ObjectMapping;
using DemoApplication.WebAPI.Transports;

namespace DemoApplication.WebAPI.Services
{
    public class EmployeeService : IEmployeeService
    {
      

        private readonly IEmployeeMappingService _employeeMappingService;


        private readonly ApplicationDbContext _applicationDbContext;
        public EmployeeService(ApplicationDbContext applicationDbContext, IEmployeeMappingService employeeMappingService)
        {
            _applicationDbContext = applicationDbContext;
            _employeeMappingService = employeeMappingService;
        }

        public void Add(EmployeeTransport entity)
        {
            var employee = _employeeMappingService.MapToEmployee(entity);

            _applicationDbContext.Employee.Add(employee);

            _applicationDbContext.SaveChanges();      
        
        }

        public EmployeeTransport Get(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EmployeeTransport> GetAll()
        {
            throw new NotImplementedException();
        }

        mployeeTransport GetBySearchTerm(string searchTerm);

        public void Update(EmployeeTransport entity)
        {
            throw new NotImplementedException();
        }




        //public EmployeeTransport Get(long id)
        //{
        //    return _applicationDbContext.Employee.Where(x=>x.Id == id).FirstOrDefault();
        //}

        //public IEnumerable<EmployeeTransport> GetAll()
        //{
        //    return _applicationDbContext.Employee.ToList();
        //}

        //public EmployeeTransport GetByName(string name)
        //{
        //    return _applicationDbContext.Employee.Where(x => x.FirstName == name).FirstOrDefault();
        //}

        //public void Update(EmployeeTransport entity)
        //{
        //    if (entity.Id != 0 || entity.Id != null) {

        //        var modifiedDate = DateTime.Now;

        //        var dbEntity = _applicationDbContext.Employee.Where(x => x.Id == entity.Id).FirstOrDefault();

        //        dbEntity.FirstName = entity.FirstName;
        //        dbEntity.LastName = entity.LastName;
        //        dbEntity.MiddleName = entity.MiddleName;
        //        dbEntity.BirthDate = entity.BirthDate;
        //        dbEntity.UpdatedOn = modifiedDate;
        //        dbEntity.UpdatedBy = "User";
        //        dbEntity.EmployeeStatus = entity.EmployeeStatus;

        //        _applicationDbContext.SaveChanges();

        //    }


        //}



    }
}
