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

        // get list of managers from temp file
        public List<TaskEntry> Tasks => _context.Tasks.ToList();

        public void AddTask(TaskEntry task)
        {
            // add manager and save changes, middle man for this stuff
            _context.Add(task);
            _context.SaveChanges();
        }
    }
}
