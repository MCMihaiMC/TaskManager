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
            //IEnumerable<Job> jobs = tasks.ListTasks;
            viewModel.ListSteps = GetSteps(Id);
            return View(viewModel);
        }



        [HttpGet]
        public IEnumerable<Job> GetTasks()
        {
            IEnumerable<Job> tasksList = _taskLoadHandler.GetTasks();
            viewModel.ListTasks = tasksList;
            return tasksList;
        }

        [HttpGet("{taskId}")]
        public IEnumerable<Step> GetSteps(int taskId)
        {
            return _taskLoadHandler.GetSteps(taskId);
        }

        [HttpGet("step/{parentStepId}")]
        public IEnumerable<Step> LoadStepChildren(int parentStepId)
        {
            return _taskLoadHandler.GetStepsByParentId(parentStepId);
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