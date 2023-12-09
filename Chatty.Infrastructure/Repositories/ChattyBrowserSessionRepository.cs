using Chatty.ApplicationCore.Entities;
using Chatty.ApplicationCore.Interfaces.Repositories;
using Chatty.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Chatty.Infrastructure.Repositories;
public class ChattyBrowserSessionRepository : IChattyBrowserSessionRepository
{
    private readonly ChattyDbContext _context;

    public ChattyBrowserSessionRepository(ChattyDbContext context)
    {
        _context = context;
    }

    public async Task<ChattyBrowserSession> Add(ChattyBrowserSession chattyBrowserSession)
    {
        var result = await _context.ChattyBrowserSessions.AddAsync(chattyBrowserSession);
        await _context.SaveChangesAsync();
        return result.Entity;
    }

    public async void DeleteById(int chattyBrowserSessionId)
    {
        var result = await _context.ChattyBrowserSessions.FirstOrDefaultAsync(b => b.Id == chattyBrowserSessionId);
        if (result != null)
        {
            result.Deleted = 1;
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<ChattyBrowserSession>> GetAll()
    {
        return await _context.ChattyBrowserSessions.Where(b => b.Deleted == 0).ToListAsync();
    }

    public async Task<ChattyBrowserSession?> GetById(int chattyBrowserSessionId)
    {
        return await _context.ChattyBrowserSessions.Where(b => b.Deleted == 0 && b.Id == chattyBrowserSessionId).FirstOrDefaultAsync();
    }

    public async Task<ChattyBrowserSession?> Update(ChattyBrowserSession chattyBrowserSession)
    {
        var result = await _context.ChattyBrowserSessions.FirstOrDefaultAsync(b => b.Id == chattyBrowserSession.Id);

        if (result == null)
        {
            return null;
        }

        result.SessionUuid = chattyBrowserSession.SessionUuid;
        result.UpdatedAt = chattyBrowserSession.UpdatedAt;
        result.UpdatedAtGmt = chattyBrowserSession.UpdatedAtGmt;

        await _context.SaveChangesAsync();

        return result;

    }
}
