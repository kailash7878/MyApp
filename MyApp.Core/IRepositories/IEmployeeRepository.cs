using MyApp.Core.Interface;
using MyApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Core.IRepositories
{
    public class IEmployeeRepository : IGenericRepository<Employee>
    {
        public Employee Add(Employee entity)
        {
            throw new NotImplementedException();
        }

        public ICollection<Employee> AddRange(ICollection<Employee> entities)
        {
            throw new NotImplementedException();
        }

        public void Delete(Employee entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteRange(ICollection<Employee> entities)
        {
            throw new NotImplementedException();
        }

        public void Update(Employee entity)
        {
            throw new NotImplementedException();
        }

        public ICollection<Employee> UpdateRange(ICollection<Employee> entities)
        {
            throw new NotImplementedException();
        }
    }
}
