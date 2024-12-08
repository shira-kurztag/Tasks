using EX2.Repositories;
using EX2.services;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Net.Mail;
using EX2.models;
namespace EX2.controller;


    [Route("api/[controller]")]
    [ApiController]
    public class AttachmentController : ControllerBase
    {
        private readonly IAttachmentService _attachmentsService;
        public AttachmentController(IAttachmentService attachmentsService)
        {
            _attachmentsService = attachmentsService;
        }

        [HttpPost("creat")]
        public IActionResult CreateAttachment([FromBody] Attachments a)
        {
            if (a == null || string.IsNullOrEmpty(a.NameAttachments) || string.IsNullOrEmpty(a.Route))
            {
                return BadRequest("All fields are required.");
            }

            DataTable result = _attachmentsService.CreateAttachment(a.NameAttachments, a.Route);
            return Ok(result);
        }

        //[HttpPost]
        //public IActionResult CreateAt([FromBody] Attachments models)
        //{
        //    if (models == null || models.NameAttachments == null || models.Route == null)
        //    {
        //        return BadRequest("Attachment and Task are required.");
        //    }

        //    bool success = _attachmentsService.CreateAt(Attachments models);
        //    if (success)
        //    {
        //        return Ok("Transaction completed successfully.");
        //    }
        //    return StatusCode(500, "Failed to process transaction.");
        //}
    
}
