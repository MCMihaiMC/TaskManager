using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using TaskManager.Business;
using TaskManager.Business.BusinessEntities;
using TaskManager.Models;

namespace TaskManager.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITaskLoadHandler _taskLoadHandler;
        private ViewModel viewModel = new ViewModel();

        public HomeController(ILogger<HomeController> logger, ITaskLoadHandler taskLoadHandler)
        {
            _logger = logger;
            _taskLoadHandler = taskLoadHandler;
        }

        [HttpGet]
        public IActionResult Index()
        {
            viewModel.ListTasks = GetTasks();
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Index(string taskId)
        {
            int Id = 1;
            viewModel.ListSteps = _taskLoadHandler.GetSteps(Id);
            return View(viewModel);
        }

        [HttpGet]
        public IEnumerable<Job> GetTasks()
        {
            IEnumerable<Job> tasksList = _taskLoadHandler.GetTasks();
            viewModel.ListTasks = tasksList;
            return tasksList;
        }

        [HttpGet("getsteps/{taskId}")]
        public PartialViewResult GetSteps(int taskId)
        {
            var data = _taskLoadHandler.GetSteps(taskId);
            return PartialView("_steps", data);
        }

        [HttpGet("getchildrensteps/{parentStepId}")]
        public PartialViewResult GetChildrenSteps(int parentStepId)
        {
            var data = _taskLoadHandler.GetStepsByParentId(parentStepId);
            return PartialView("_stepChilds", data);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}