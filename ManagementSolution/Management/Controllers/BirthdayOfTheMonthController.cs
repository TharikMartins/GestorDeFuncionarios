using System;
using Management.Parse;
using Management.Services.Employee.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Management.Controllers
{
    public class BirthdayOfTheMonthController : Controller
    {
        private IEmployeeService _employeeService;
        private readonly ILogger<BirthdayOfTheMonthController> _logger;
        public BirthdayOfTheMonthController(IEmployeeService employeeService, ILogger<BirthdayOfTheMonthController> logger)
        {
            this._employeeService = employeeService;
            this._logger = logger;
        }
        public IActionResult Index()
        {
            try
            {
                var birthdayList = this._employeeService.GetBirthdayOfTheMonth();
                return View(ParseDTO.ParseBirthdayList(birthdayList));
            }
            catch(Exception ex)
            {
                this._logger.LogError(ex.Message);
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
