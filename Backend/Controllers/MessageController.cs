using Backend.Models.DTO;
using Backend.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly MessageRepository _messageRepository;

        public MessageController(MessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        [HttpPost]
        public async Task<IActionResult> SaveMessage(MessageRequest message)
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest(message);
            }
            await _messageRepository.GetMessage(message);
            return Created("", null);
        }
    }
}
