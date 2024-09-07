using Company.Data.Entities;
using Company.Repository.Interfaces;
using Company.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Service.Services.Employee
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void Add(Data.Entities.Employee employee)
        {
            throw new NotImplementedException();
        }

        public void Delete(Data.Entities.Employee employee)
        {
            _unitOfWork.EmployeeRepository.Delete(employee);
            _unitOfWork.Complete();
        }

        public IEnumerable<Data.Entities.Employee> GetAll()
        {
            var employees = _unitOfWork.EmployeeRepository.GetAll();
            return employees;
        }

        public Data.Entities.Employee GetById(int? id)
        {
            if (id is null)
                return null;

            var employee = _unitOfWork.EmployeeRepository.GetById(id.Value);

            if (employee == null)
                return null;

            return employee;
        }

        public IEnumerable<Data.Entities.Employee> GetEmployeeByName(string name)
        => _unitOfWork.EmployeeRepository.GetEmployeeByName(name);

        public void Update(Data.Entities.Employee employee)
        {
            _unitOfWork.EmployeeRepository.Update(employee);
            _unitOfWork.Complete();
        }
    }
}
