using Chatty.ApplicationCore.Entities;
using Chatty.ApplicationCore.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Chatty.WebApi.Controllers;

[ApiController]
[Route("test")]
public class TestController : ControllerBase
{

    IChattyBrowserSessionRepository _chattyBrowserRepository;

    public TestController(IChattyBrowserSessionRepository chattyBrowserSessionRepository)
    {
        _chattyBrowserRepository = chattyBrowserSessionRepository;
    }

    [HttpGet]
    [Route("addTest")]
    public async Task<IActionResult> Test()
    {

        //var result = await _chattyBrowserRepository.DeleteByIdAsync(2);

        //return Ok(result);

        //var chattyBrowserSession = new ChattyBrowserSession { SessionUuid = Guid.NewGuid().ToString() };

        //var result = await _chattyBrowserRepository.AddAsync(chattyBrowserSession);

        //return Ok(result);

        var result = await _chattyBrowserRepository.GetAllAsync();

        List<ChattyBrowserSession> chattyBrowserSessions = new List<ChattyBrowserSession>(result.ToArray());

        Console.WriteLine("Count is " + chattyBrowserSessions.Count);


        foreach (var session in chattyBrowserSessions)
        {
            Console.WriteLine(session.Id + " " + session.SessionUuid);
        }

        return Ok(chattyBrowserSessions);

    }

}