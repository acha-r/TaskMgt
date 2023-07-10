using TaskMgt.Context;
using TaskMgt.Models;

namespace TaskMgt.Services
{
    public class TaskServices : ITaskService
    {
        private readonly AppDbContext _context;

        public TaskServices(AppDbContext context)
        {
            _context = context;
        }
        public Tasks AssignTask(int taskId, string email)
        {
            var task = _context.Tasks.Find(taskId) ?? throw new KeyNotFoundException("Invalid task Id");
            task.Owner = email;

            _context.Tasks.Update(task);
            _context.SaveChanges();
            return task;
             
        }

        public Tasks CreateTask(Tasks task)
        {
            _context.Tasks.Add(task);
            _context.SaveChanges();
            return task;
        }

        public void DeleteTask(int taskId)
        {
            var task = _context.Tasks.Find(taskId) ?? throw new KeyNotFoundException("Invalid task id");
            _context.Tasks.Remove(task);
            _context.SaveChanges();
        }

        public IEnumerable<Tasks> GetTasks()
        {
            return _context.Tasks.ToList();
        }
    }
}
