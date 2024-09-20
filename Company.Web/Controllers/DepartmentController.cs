using Company.Data.Entities;
using Company.Repository.Interfaces;
using Company.Service.Interfaces;
using Company.Service.Interfaces.Department.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Company.Web.Controllers
{
    [Authorize]
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var departemnts = _departmentService.GetAll();
            return View(departemnts);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(DepartmentDto department) {
            try {
                if (ModelState.IsValid)
                {
                    _departmentService.Add(department);
                    //return RedirectToAction("Index");
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("DepartmentError", "ValidationErrors");

                return View(department);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("DepartmentError", ex.Message);

                return View(department);
            }
            
        }

        public IActionResult Details(int? id, string viewName="Details") 
        {
            var department = _departmentService.GetById(id);

            if (department is null)
                return RedirectToAction("NotFoundPage", null, "Home");

            return View(viewName,department);
        }

        [HttpGet]

        public IActionResult Update(int? id)
        {
            return Details(id, "Update");
        }
        [HttpPost]
        public IActionResult Update(int? id, DepartmentDto department)
        {
            if (department.Id != id.Value)
                return RedirectToAction("NotFoundPage", null, "Home");

            _departmentService.Update(department);

            return RedirectToAction(nameof(Index));

        }
     
        public IActionResult Delete(int? id) 
        {
            var department = _departmentService.GetById(id);

            if (department is null)
                return RedirectToAction("NotFoundPage", null, "Home");

            _departmentService.Delete(department);
            return RedirectToAction(nameof(Index));



        }


    }
}
