using EX2.models;
using System.Threading.Tasks;

namespace EX2.services
{
    public interface ITaskService
    {
        IEnumerable<TaskModel> GetTasks();
        string addTask(string Id, string Name,  string Status,string DueDate,string UserId, string ProjectId);
        void DeleteTaskById(string id);
        void updateTask(TaskModel newTask);
        IEnumerable<TaskModel> GetTasksByUserName(string Id);
    }
}
