using MyApp.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Serviecs.Services
{
    
    public class EmployeeServices
    {
        private readonly IUnitOfWork _uow;
        public EmployeeServices(IUnitOfWork uow)
        {
            _uow = uow;
        }
    }
}
