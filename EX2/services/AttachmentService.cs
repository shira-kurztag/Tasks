using EX2.Repositories;
using System.Data;

namespace EX2.services
{
    public class AttachmentService : IAttachmentService
    {
        private readonly IAttachmentRepository _attachmentsRepository;

        public AttachmentService(IAttachmentRepository attachmentsRepository)
        {
            _attachmentsRepository = attachmentsRepository;
        }
        public DataTable CreateAttachment(string attachmentName, string attachmentPath)
        {
            return _attachmentsRepository.CreateAttachment(attachmentName, attachmentPath);
        }
        public bool CreateAt(AttachmentWithTask model)
        {
            return _attachmentsRepository.ProcessTransaction(model.Task, model.);
        }
    }
}
