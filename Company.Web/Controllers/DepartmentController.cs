﻿using Company.Data.Entities;
using Company.Repository.Interfaces;
using Company.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Company.Web.Controllers
{
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
        public IActionResult Create(Department department) {
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
    }
}
