using Microsoft.EntityFrameworkCore;
using EX2.models;

namespace EX2.Repositories
{
    public class TaskDBContext: DbContext
    {
        public TaskDBContext(DbContextOptions<TaskDBContext> option) : base(option)
        {

        }
        public DbSet<TaskModel> Tasks { get; set; }
        public DbSet<ProjectModel> Project { get; set; }
        public DbSet<UsersModel> Users { get; set; }
    }
}
