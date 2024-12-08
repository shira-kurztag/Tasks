using EX2.models;

namespace EX2.Repositories
{
    public interface ITaskRepository
    {
          
        IEnumerable<TaskModel> GetTasks();
        string addTask(TaskModel newTask);
        void DeleteTaskById(string id);
        //void SaveChanges(List<TaskModel> newListTasks);
        void updateTask(TaskModel newTask);
        IEnumerable<TaskModel> GetTasksByUserName(string id);


    }
}

