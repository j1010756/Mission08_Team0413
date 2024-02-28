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


        // Desired Routes for the application

        // Route to the Quadrant view, to display the tasks in the respective quadrants
        //Get Rout to CreateTask view, to create a new task (likely will have to pass a new TaskEntry object to the view)
        //Post Route to CreateTask view, to create a new task

        //Get Route to the CreateTask view, but pass it an existing task to edit
        //Post Route to the CreateTask view, to edit an existing task

        //Get Route to the DeleteTask view, to delete an existing task
        //Post Route to the DeleteTask view, to delete an existing task



    }
}
