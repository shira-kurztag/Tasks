using EX2.models;
using System.Data;
using System.Net.Mail;

namespace EX2.Repositories
{
    public interface IAttachmentRepository
    {
        DataTable CreateAttachment(string attachmentName, string attachmentPath);
        public bool ProcessTransaction(Attachments attachment, models.TaskModel task);

    }
}
