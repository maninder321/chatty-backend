using Microsoft.AspNetCore.Mvc;

namespace Chatty.WebApi.Controllers;

public class ChattySessionController : ControllerBase
{

    public async Task<IActionResult> createSession()
    {
        return Ok("hello");
    }
}
