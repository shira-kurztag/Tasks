﻿using EX2.Repositories;
using EX2.models;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using EX2.services.Logger;

namespace EX2.services
{
    public class TaskService: ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly ILoggerService _logger;
        private readonly services.Logger.LoggerFactory _loggerFactory;
        public TaskService(ITaskRepository taskRepository,services.Logger.LoggerFactory loggerFactory)
        {
            _taskRepository = taskRepository;
            _loggerFactory = loggerFactory;
            _logger = _loggerFactory.GetLogger("database");
        }
        public IEnumerable<TaskModel> GetTasks()
        {
            _logger.Log("database");


            return _taskRepository.GetTasks();
        }
        public IEnumerable<TaskModel> GetTasksByUserName(string Id)
        {
            var tasks = _taskRepository.GetTasksByUserName(Id).Where(x=> x.UserId ==Id);
            return tasks;
        }


        public string addTask(string Id, string Name, string Status,string DueDate ,string ProjectId,string UserId)
        {
            TaskModel newTask = new TaskModel();
            newTask.Id = Id;
            newTask.Name = Name;
            newTask.Status = Status;
            newTask.DueDate = DueDate;
            newTask.ProjectId = ProjectId;
            newTask.UserId = UserId;
            _taskRepository.addTask(newTask);
             return "Ok";
        }
        public void DeleteTaskById(string id)
        {
            _taskRepository.DeleteTaskById(id);
        }
        public void updateTask(TaskModel newTask)
        {
            _taskRepository.updateTask(newTask);
        }
    }
}