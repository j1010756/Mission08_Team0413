namespace Mission08_Team0413.Models
{
    public interface ITaskRepository
    {
        // get tasks
        List<TaskEntry> Tasks { get; }

        List<Category> Categories { get; }

        // make new task
        public void AddTask(TaskEntry task);

        // edit task
        public void EditTask(TaskEntry updatedTask);

        // delete task
        public void DeleteTask(TaskEntry record);
    }
}
