using ChatModels;
using DemoChat.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoChat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController(ChatRepository _chatRepository) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<Chat>>> GetChatsAsync()
        {
            return Ok(await _chatRepository.GetChatsAsync());
        }
    }
}
