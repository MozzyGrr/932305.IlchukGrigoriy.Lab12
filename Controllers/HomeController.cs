using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using lab12.Models;

namespace lab12.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
           
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [HttpPost]
        public IActionResult ProcessManualSingle()
        {
            string result = null;
            double num1 = 0;
            double num2 = 0;
            string operation = null;

            if (Request.Method == "POST")
            {
                num1 = double.TryParse(Request.Form["Number1"], out var n1) ? n1 : 0;
                num2 = double.TryParse(Request.Form["Number2"], out var n2) ? n2 : 0;
                operation = Request.Form["Operation"];

                result = operation switch
                {
                    "+" => (num1 + num2).ToString(),
                    "-" => (num1 - num2).ToString(),
                    "*" => (num1 * num2).ToString(),
                    "/" => num2 != 0 ? (num1 / num2).ToString() : "Ошибка: деление на ноль",
                    _ => "Неизвестная операция"
                };
            }
            ViewBag.Number1 = num1; 
            ViewBag.Number2 = num2;
            ViewBag.Operation = operation;
            ViewBag.Result = result;
            ViewData["Result"] = result;
            return View();
        }

        [HttpGet]
        public IActionResult ProcessManualSeparate(int? id = null)
        {
            return View();
        }

        [HttpPost]
        public IActionResult ProcessManualSeparate()
        {
            string result = null;
            double num1 = 0;
            double num2 = 0;
            string operation = null;

            if (Request.Method == "POST")
            {
                num1 = double.TryParse(Request.Form["Number1"], out var n1) ? n1 : 0;
                num2 = double.TryParse(Request.Form["Number2"], out var n2) ? n2 : 0;
                operation = Request.Form["Operation"];

                result = operation switch
                {
                    "+" => (num1 + num2).ToString(),
                    "-" => (num1 - num2).ToString(),
                    "*" => (num1 * num2).ToString(),
                    "/" => num2 != 0 ? (num1 / num2).ToString() : "Ошибка: деление на ноль",
                    _ => "Неизвестная операция"
                };
            }
            ViewBag.Number1 = num1; 
            ViewBag.Number2 = num2;
            ViewBag.Operation = operation;
            ViewBag.Result = result;
            ViewData["Result"] = result;
            return View();
        }

        [HttpGet]
        public IActionResult ProcessBindingParameters(int? id = null)
        {
            return View();
        }

        [HttpPost]
        public IActionResult ProcessBindingParameters(double num1, double num2, string operation)
        {
            string result = null;

                result = operation switch
                {
                    "+" => (num1 + num2).ToString(),
                    "-" => (num1 - num2).ToString(),
                    "*" => (num1 * num2).ToString(),
                    "/" => num2 != 0 ? (num1 / num2).ToString() : "Ошибка: деление на ноль",
                    _ => "Неизвестная операция"
                };

            ViewBag.Result = result;
            ViewData["Result"] = result;
            return View();
        }


        [HttpGet]
        public IActionResult ProcessBindingModel(int? id = null)
        {
            return View(new Value());
        }

        [HttpPost]
        public IActionResult ProcessBindingModel(Value model)
        {
            model.Result = null;

            model.Result = model.Operation switch
            {
                "+" => (model.Num1 + model.Num2).ToString(),
                "-" => (model.Num1 - model.Num2).ToString(),
                "*" => (model.Num1 * model.Num2).ToString(),
                "/" => model.Num1 != 0 ? (model.Num1 / model.Num2).ToString() : "Ошибка: деление на ноль",
                _ => "Неизвестная операция"
            };

            return View(model);
        }

    }
}