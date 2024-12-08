using Microsoft.Data.SqlClient;
using System.Data;
using EX2.models;
using System.Net.Mail;
namespace EX2.Repositories
{
    public class AttachmentWithTask : IAttachmentRepository
    {
        private readonly string _cnn;
        public AttachmentWithTask(IConfiguration configuration)
        {
            _cnn = configuration.GetConnectionString("DefaultConnection");
        }

        public object Task { get; internal set; }

        public DataTable CreateAttachment(string NameAttachments, string Route)
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(_cnn))
            {
                using (SqlCommand command = new SqlCommand("AddAttachment", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@AttachmentNameAttachments", NameAttachments));
                    command.Parameters.Add(new SqlParameter("@attachmentRoute", NameAttachments));
                    connection.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(command))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }
        public bool ProcessTransaction(Attachments attachment, models.TaskModel task)
        {
            using (SqlConnection connection = new SqlConnection(_cnn))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    using (SqlCommand command1 = new SqlCommand("INSERT INTO Tasks (Name, TaskName, TaskDescription,UserId, ProjectId )  VALUES (@Name, @TaskName, @TaskDescription, @UserId, @ProjectId)", connection, transaction))
                    {
                        command1.Parameters.AddWithValue("@Id", task.Id);
                        command1.Parameters.AddWithValue("@Name", task.Name);
                        command1.Parameters.AddWithValue("@DueDate", task.DueDate);
                        command1.Parameters.AddWithValue("@UserId", task.UserId);
                        command1.Parameters.AddWithValue("@ProjectId", task.ProjectId);
                        command1.ExecuteNonQuery();
                    }

                    using (SqlCommand command2 = new SqlCommand("INSERT INTO Attachments (NameAttachments,Route) VALUES (@NameAttachments,@Route)", connection, transaction))
                    {
                        command2.Parameters.AddWithValue("@Route", attachment.Route);
                      
                        command2.Parameters.AddWithValue("@NameAttachments", attachment.NameAttachments);
                        command2.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    Console.WriteLine("Transaction committed.");
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    Console.WriteLine($"Stack Trace: {ex.StackTrace}");
                    transaction.Rollback();
                    return false;
                }
            }
        }

        public bool ProcessTransaction(Attachment attachment, TaskModel task)
        {
            throw new NotImplementedException();
        }

        DataTable IAttachmentRepository.CreateAttachment(string attachmentName, string attachmentPath)
        {
            throw new NotImplementedException();
        }

        bool IAttachmentRepository.ProcessTransaction(Attachments attachment, TaskModel task)
        {
            throw new NotImplementedException();
        }

        //bool IAttachmentRepository.ProcessTransaction(Attachments attachment, TaskModel task)
        //{
        //    throw new NotImplementedException();
        //}
    }

}
