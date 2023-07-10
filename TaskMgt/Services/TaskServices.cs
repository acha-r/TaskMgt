using Microsoft.AspNetCore.Identity;
using TaskMgt.Context;
using TaskMgt.Models;

namespace TaskMgt.Services
{
    public class TaskServices : ITaskService
    {
        private readonly AppDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;


        public TaskServices(AppDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<Tasks> AssignTask(int taskId, string email)
        {
            var task = await _context.Tasks.FindAsync(taskId) ?? throw new KeyNotFoundException("Invalid task Id");
            task.Owner = email;

            var user = await _userManager.FindByEmailAsync(email);
            user.Tasks.Add(task);

            _context.Tasks.Update(task);
            await _context.SaveChangesAsync();
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
