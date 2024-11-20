using EX2.models;
using System.Threading.Tasks;

namespace EX2.Repositories
{
    public interface ITaskRepository
    {
        IEnumerable<TaskModel> GetTasks();
        IEnumerable<TaskModel> GetTasksByUserName(string Id);
        string addTask(TaskModel newTask);
        void DeleteTaskById(string id);
        //void SaveChanges(List<TaskModel> newListTasks);
        void updateTask(TaskModel newTask);

    }
}
