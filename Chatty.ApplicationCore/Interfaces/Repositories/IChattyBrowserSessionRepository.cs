using Chatty.ApplicationCore.Entities;

namespace Chatty.ApplicationCore.Interfaces.Repositories;
public interface IChattyBrowserSessionRepository
{
    Task<IEnumerable<ChattyBrowserSession>> GetAllAsync();
    Task<ChattyBrowserSession?> GetByIdAsync(int chattyBrowserSessionId);
    Task<ChattyBrowserSession> AddAsync(ChattyBrowserSession chattyBrowserSession);
    Task<ChattyBrowserSession?> UpdateAsync(ChattyBrowserSession chattyBrowserSession);
    Task<ChattyBrowserSession?> DeleteByIdAsync(int chattyBrowserSessionId);

}
