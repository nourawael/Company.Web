﻿using Company.Data.Entities;
using Company.Service.Interfaces;
using Company.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace Company.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IDepartmentService _departmentService;

        public EmployeeController(IEmployeeService employeeService, IDepartmentService departmentService)
        {
            _employeeService = employeeService;
            _departmentService = departmentService;
        }
      

       [HttpGet]
        public IActionResult Index(string searchInp)
        {
            IEnumerable<Employee> employees = new List<Employee>();
            if (string.IsNullOrEmpty(searchInp))
            
                employees = _employeeService.GetAll();
               
            else 
                 employees = _employeeService.GetEmployeeByName(searchInp);
              
            return View(employees);

        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Departments=_departmentService.GetAll();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
           
            try
            {
                if (ModelState.IsValid)
                {
                    _employeeService.Add(employee);
                    //return RedirectToAction("Index");
                    return RedirectToAction(nameof(Index));
                }
              

                return View(employee);
            }
            catch (Exception ex)
            {
              

                return View(employee);
            }
        }

        //public IActionResult Details()
        //{

        //}

        //[HttpGet]

        //public IActionResult Update(int? id)
        //{

        //}
        //[HttpPost]
        //public IActionResult Update(int? id, Department department)
        //{

        //}

        //public IActionResult Delete(int? id)
        //{


        //}

    }
}
