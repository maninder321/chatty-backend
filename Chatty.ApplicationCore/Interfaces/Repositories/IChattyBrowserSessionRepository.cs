using Chatty.ApplicationCore.Entities;

namespace Chatty.ApplicationCore.Interfaces.Repositories;
public interface IChattyBrowserSessionRepository
{
    Task<IEnumerable<ChattyBrowserSession>> GetAll();
    Task<ChattyBrowserSession?> GetById(int chattyBrowserSessionId);
    Task<ChattyBrowserSession> Add(ChattyBrowserSession chattyBrowserSession);
    Task<ChattyBrowserSession?> Update(ChattyBrowserSession chattyBrowserSession);
    void DeleteById(int chattyBrowserSessionId);

}
