﻿using Company.Data.Contexts;
using Company.Data.Entities;
using Company.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Repository.Repositories
{

    public class EmployeeRepository : IEmployeeRepository
    {
        // dependency injection
        private readonly CompanyDbContext _context;

        public EmployeeRepository(CompanyDbContext context)
        {
            _context = context;
        }
        public void Add(Employee employee)
        => _context.Add(employee);

        public void Delete(Employee employee)
        => _context.Remove(employee);

        public IEnumerable<Employee> GetAll()
        => _context.Employees.ToList();

        public Employee GetById(int id)
        //=> _context.Employees.FirstOrDefault(x => x.Id == id);
        => _context.Employees.Find(id);

        public void Update(Employee employee)
        => _context.Update(employee);
    }
}
