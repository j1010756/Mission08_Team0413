namespace Mission08_Team0413.Models
{
    public interface ITaskRepository
    {
        // get tasks
        List<TaskEntry> Tasks { get; }

        // make new task
        public void AddTask(TaskEntry task);
    }
}
