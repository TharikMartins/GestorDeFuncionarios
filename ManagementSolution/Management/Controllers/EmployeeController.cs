using System;
using Management.Models;
using Management.Parse;
using Management.Services.Employee.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Management.Controllers
{
    public class EmployeeController : Controller
    {

        private IEmployeeService _employeeService;
        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(IEmployeeService employeeService, ILogger<EmployeeController> logger)
        {
            this._employeeService = employeeService;
            this._logger = logger;
        }

        public ActionResult Index()
        {

            var employeesDTO = this._employeeService.List();

            return View(ParseDTO.ParseEmployee(employeesDTO));
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Create([FromForm] EmployeeViewModel Request)
        {
            try
            {
                this._employeeService.Save(ParseDTO.ParseEmployee(Request));
                return Json(new { Success = true });
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.Message);
                return Json(new { Success = false });
            }
        }

        public ActionResult Edit(int id)
        {
            try
            {
                var employeeDTO = this._employeeService.FindEmployeeById(id);

                return View(ParseDTO.ParseEmployee(employeeDTO));
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.Message);
                return RedirectToAction(nameof(Index));
            }

        }

        [HttpPost]
        public JsonResult Edit([FromForm] EmployeeViewModel Request)
        {
            try
            {
                this._employeeService.UpdateEmployee(ParseDTO.ParseEmployee(Request));
                return Json(new { Success = true });
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.Message);
                return Json(new { Success = false });
            }
        }

        public ActionResult Delete(int id)
        {
            try
            {
                this._employeeService.Delete(id);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.Message);

                return RedirectToAction(nameof(Index));
            }

        }
    }
}
