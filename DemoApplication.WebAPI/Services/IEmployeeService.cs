﻿using DemoApplication.WebAPI.Models;
using DemoApplication.WebAPI.Transports;

namespace DemoApplication.WebAPI.Services
{
    public interface IEmployeeService : IBaseDataRepository<EmployeeTransport>
    {
        EmployeeTransport GetBySearchTerm(string searchTerm);
    }
}
