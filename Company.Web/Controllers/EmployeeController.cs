using Company.Data.Entities;
using Company.Service.Interfaces;
using Company.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace Company.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
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
        //[HttpGet]
        //public IActionResult Create()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public IActionResult Create()
        //{
        //}

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
