using Company.Data.Contexts;
using Company.Data.Entities;
using Company.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Repository.Repositories
{

    public class EmployeeRepository :GenericRepository<Employee> ,IEmployeeRepository
    {
        // dependency injection
        private readonly CompanyDbContext _context;
        public EmployeeRepository(CompanyDbContext context):base(context) 
        {
            _context = context;
        }

        public Employee GetEmployeeByName(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> GetEmployeesByAddress(string address)
        {
            throw new NotImplementedException();
        }
    }
}
