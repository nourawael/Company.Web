﻿
using Company.Data.Entities;
using Company.Repository.Interfaces;
using Company.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Service.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        public void Add(Department department)
        {
            throw new NotImplementedException();
        }

        public void Delete(Department department)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Department> GetAll()
        {
            var departments = _departmentRepository.GetAll();
            return departments;
        }

        public Department GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Department department)
        {
            throw new NotImplementedException();
        }
    }
}
