using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission08_Team0413.Models;
using System.Diagnostics;
using System.Diagnostics.Contracts;

//Test to see if Github is working

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
            // return task object
            return View(new TaskEntry());
        }

        [HttpPost]
        public IActionResult Index(TaskEntry t)
        {
            if (ModelState.IsValid)
            {
                // call add task from repo
                _repo.AddTask(t);
            }
            return View(new TaskEntry());
        }


        // Desired Routes for the application

        // Route to the Quadrant view, to display the tasks in the respective quadrants
        public IActionResult Quadrant()
        {
            var tasks = _repo.Tasks.ToList();

            return View(tasks);
        }

        //Get Rout to CreateTask view, to create a new task (likely will have to pass a new TaskEntry object to the view)
        [HttpGet] 
        public IActionResult CreateTask() 
        {
            ViewBag.Categories = _repo.Categories.ToList();
            return View("CreateTask", new TaskEntry());
        }
        //Post Route to CreateTask view, to create a new task

        [HttpPost]
        public IActionResult CreateTask(TaskEntry t)
        {
            if (ModelState.IsValid)
            {
                _repo.AddTask(t);
                ViewBag.Categories = _repo.Categories.ToList();
                ViewBag.SuccessMessage = "Form submitted successfully!";
                return View("CreateTask", t);
            }
            else
            {
                ViewBag.Categories = _repo.Categories.ToList();
                return View(t);
            }
        }

        //Get Route to the CreateTask view, but pass it an existing task to edit
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recordToEdit = _repo.Tasks
                .Single(x => x.TaskId == id);

            return View("CreateTask", recordToEdit);
        }



        //Post Route to the CreateTask view, to edit an existing task

        [HttpPost]
        public IActionResult Edit(TaskEntry updatedTask)
        {
            if (ModelState.IsValid)
            {
                // access repo to edit task
                _repo.EditTask(updatedTask);

                return RedirectToAction("Quadrant");
            }
            else
            {
                return View("CreateTask", updatedTask);
            }
        }
        //Get Route to the DeleteTask view, to delete an existing task
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var recordToDelete = _repo.Tasks
                .Single(x => x.TaskId == id);

            return View(recordToDelete);
        }
        //Post Route to the DeleteTask view, to delete an existing task
        [HttpPost]

        public IActionResult Delete(TaskEntry record)
        {
            _repo.DeleteTask(record);

            return RedirectToAction("Quadrant");
        }


    }
}
