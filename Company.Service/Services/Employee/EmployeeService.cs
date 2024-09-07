using AutoMapper;
using Company.Data.Entities;
using Company.Repository.Interfaces;
using Company.Service.Interfaces;
using Company.Service.Interfaces.Employee.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Service.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmployeeService(IUnitOfWork unitOfWork , IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public void Add(EmployeeDto employeeDto)
        {
            //Employee employee = new Employee 
            //{
            //    Address= employeeDto.Address,
            //    Age= employeeDto.Age,
            //    DepartmentId= employeeDto.DepartmentId,
            //    Email= employeeDto.Email,
            //    ImageUrl= employeeDto.ImageUrl,
            //    Name= employeeDto.Name,
            //    PhoneNumber= employeeDto.PhoneNumber,
            //    Salary= employeeDto.Salary,
             
            //};

            Employee employee = _mapper.Map<Employee>(employeeDto);

            _unitOfWork.EmployeeRepository.Add(employee);
            _unitOfWork.Complete();
            
        }

        public void Delete(EmployeeDto employeeDto)
        {
            //Employee employee = new Employee
            //{
            //    Address = employeeDto.Address,
            //    Age = employeeDto.Age,
            //    DepartmentId = employeeDto.DepartmentId,
            //    Email = employeeDto.Email,
            //    ImageUrl = employeeDto.ImageUrl,
            //    Name = employeeDto.Name,
            //    PhoneNumber = employeeDto.PhoneNumber,
            //    Salary = employeeDto.Salary,

            //};
            Employee employee = _mapper.Map<Employee>(employeeDto);

            _unitOfWork.EmployeeRepository.Delete(employee);
            _unitOfWork.Complete();
        }

        public IEnumerable<EmployeeDto> GetAll()
        {
            var employees = _unitOfWork.EmployeeRepository.GetAll();
            //var mappedEmployees = employees.Select(x => new EmployeeDto
            //{
            //    DepartmentId= x.DepartmentId,
            //    Email= x.Email,
            //    ImageUrl= x.ImageUrl,
            //    Name= x.Name,
            //    PhoneNumber= x.PhoneNumber,
            //    Salary= x.Salary,
            //    Id= x.Id,
            //    Address= x.Address,
            //    Age= x.Age,
            //    CreateAt= x.CreateAt,
            //});
            IEnumerable<EmployeeDto> mappedEmployees = _mapper.Map<IEnumerable<EmployeeDto>>(employees);


            return mappedEmployees;
        }

        public EmployeeDto GetById(int? id)
        {
            if (id is null)
                return null;

            var employee = _unitOfWork.EmployeeRepository.GetById(id.Value);

            if (employee == null)
                return null;

            //EmployeeDto employeeDto = new EmployeeDto
            //{
            //    Address = employee.Address,
            //    Age = employee.Age,
            //    DepartmentId = employee.DepartmentId,
            //    Email = employee.Email,
            //    ImageUrl = employee.ImageUrl,
            //    Name = employee.Name,
            //    PhoneNumber = employee.PhoneNumber,
            //    Salary = employee.Salary,

            //};
            EmployeeDto employeeDto = _mapper.Map<EmployeeDto>(employee);


            return employeeDto;
        }

        public IEnumerable<EmployeeDto> GetEmployeeByName(string name)
        {
            var employees = _unitOfWork.EmployeeRepository.GetEmployeeByName(name);
            //var mappedEmployees = employees.Select(x => new EmployeeDto
            //{
            //    DepartmentId = x.DepartmentId,
            //    Email = x.Email,
            //    ImageUrl = x.ImageUrl,
            //    Name = x.Name,
            //    PhoneNumber = x.PhoneNumber,
            //    Salary = x.Salary,
            //    Id = x.Id,
            //    Address = x.Address,
            //    Age = x.Age,
            //    CreateAt = x.CreateAt,
            //});
            IEnumerable<EmployeeDto> mappedEmployees = _mapper.Map<IEnumerable<EmployeeDto>>(employees);

            return mappedEmployees;
        }

        public void Update(EmployeeDto employeeDto)
        {
            
           // _unitOfWork.EmployeeRepository.Update(employee);
            _unitOfWork.Complete();
        }
    }
}
