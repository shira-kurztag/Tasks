using EX2.models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Threading.Tasks;

namespace EX2.Repositories
{
    public class TaskRepository: ITaskRepository
    {
        private readonly TaskDBContext _context;
 
        public TaskRepository(TaskDBContext context)
        {
            _context = context;
        }
        public IEnumerable<TaskModel> GetTasks()
        {
            return _context.Tasks.ToList();
        }

        public IEnumerable<TaskModel> GetTasksByUserName(string Id)
        {
            return _context.Tasks.ToList();
        }



        public string addTask(TaskModel newTask)
        {

            var Projects = _context.Project.Find(newTask.ProjectId);
            if (Projects == null)
               return "Project does not exist";

            var users = _context.Users.Find(newTask.UserId);
            if (Projects == null)
               return "Users does not exist";

            _context.Tasks.Add(newTask);
            _context.SaveChanges();
            return "Successfuly!!";
        }

        public void DeleteTaskById(string id)
        {
            TaskModel? thisTask = _context.Tasks.Find(id);
            _context.Tasks.Remove(thisTask);
            _context.SaveChanges();
        }
        //public void SaveChanges(List<TaskModel> newListTasks)//כתיבת הרשימה כולל המשימה החדשה לקובץ
        //{
        //    if (!File.Exists(_filePath))
        //    {
        //        return;
        //    }
        //    var newList = JsonSerializer.Serialize(newListTasks);//ממיר  מגיסון למחרוזת
        //    File.WriteAllText(_filePath, newList);//מחזיר  משימות כמחרוזת
        //}
        public void updateTask(TaskModel newTask)
        {

            _context.Tasks.Update(newTask);
            _context.SaveChanges();
        }
    }

}
