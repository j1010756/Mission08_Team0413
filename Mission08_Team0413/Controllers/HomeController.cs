using Microsoft.AspNetCore.Mvc;
using Mission08_Team0413.Models;
using System.Diagnostics;

namespace Mission08_Team0413.Controllers
{
    public class HomeController : Controller
    {
        // make object of context
        private ITaskRepository _repo;
        public HomeController(ITaskRepository temp)
        {
            _repo = temp;
        }

        [HttpGet]
        public IActionResult Index()
        {

            return View(new TaskEntry());
        }

        [HttpPost]
        public IActionResult Index(TaskEntry t)
        {
            if (ModelState.IsValid)
            {
                // call add manager from repo
                _repo.AddTask(t);
            }
            return View(new TaskEntry());
        }
    }
}
