using TaskMgt.Models;

namespace TaskMgt.Services
{
    public interface ITaskService
    {
        Tasks CreateTask(Tasks task);
        IEnumerable<Tasks> GetTasks();
        void DeleteTask(int taskId);
        Task<Tasks> AssignTask(int taskId, string email);
    }
}
