namespace Mission08_Team0413.Models
{
    // make class inherit from instance
    public class EFTaskRepository : ITaskRepository
    {
        // private variable to be seen by each method

        private TaskContext _repo;
        public EFTaskRepository(TaskContext temp)
        {
            _repo = temp;
        }

        // get list of managers from temp file
        public List<TaskEntry> Tasks => _repo.Tasks.ToList();

        public void AddTask(TaskEntry task)
        {
            // add manager and save changes, middle man for this stuff
            _repo.Add(task);
            _repo.SaveChanges();
        }
    }
}
