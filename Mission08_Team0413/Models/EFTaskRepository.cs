﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Mission08_Team0413.Models
{
    // make class inherit from instance
    public class EFTaskRepository : ITaskRepository
    {
        // private variable to be seen by each method

        private TaskContext _context;
        public EFTaskRepository(TaskContext temp)
        {
            _context = temp;
        }

        // get list of tasks from temp file
        public List<TaskEntry> Tasks => _context.Tasks.Include(x => x.Category).ToList();

        // get list of categories
        public List<Category> Categories => _context.Categories.ToList();

        public void AddTask(TaskEntry task)
        {
            // add task and save changes, middle man for this stuff
            _context.Add(task);
            _context.SaveChanges();
        }


        public void DeleteTask(TaskEntry record)
        {
            // remove record
            _context.Tasks.Remove(record);

            // confirm deletion
            _context.SaveChanges();
        }

        public void EditTask(TaskEntry updatedTask)
        {
            // update info
            _context.Update(updatedTask);

            // save change to db
            _context.SaveChanges();
        }
    }
}
