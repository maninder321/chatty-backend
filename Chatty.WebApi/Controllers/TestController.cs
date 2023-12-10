using Chatty.ApplicationCore.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Chatty.WebApi.Controllers;

[ApiController]
public class TestController : ControllerBase
{

    IChattyBrowserSessionRepository _chattyBrowserRepository;

    public TestController(IChattyBrowserSessionRepository chattyBrowserSessionRepository)
    {
        _chattyBrowserRepository = chattyBrowserSessionRepository;
    }

    [HttpGet]
    [Route("/addTest")]
    public IActionResult Test()
    {

        var result = _chattyBrowserRepository.GetAll();

        Console.WriteLine(result);

        return Ok("Hello World");
    }

}