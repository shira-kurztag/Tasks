using EX2.Repositories;
using System.Data;

namespace EX2.services
{
    public interface IAttachmentService
    {
        DataTable CreateAttachment(string Route, string NameAttachments);
        bool CreateAt(AttachmentWithTask model);

    }
}
