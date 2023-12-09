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

        String userTimeZone = "Asia/Kolkata";
        TimeZoneInfo timeZoneUser = TimeZoneInfo.FindSystemTimeZoneById(userTimeZone);
        DateTime currentTimeInUserTimeZone = TimeZoneInfo.ConvertTime(DateTime.Now, timeZoneUser);

        String gmtTimeZone = "GMT";
        TimeZoneInfo timeZoneGmt = TimeZoneInfo.FindSystemTimeZoneById(gmtTimeZone);
        DateTime currentTimeInGmt = TimeZoneInfo.ConvertTime(DateTime.Now, timeZoneGmt);

        chattyBrowserSession.CreatedAt = currentTimeInUserTimeZone;
        chattyBrowserSession.CreatedAtGmt = currentTimeInGmt;
        chattyBrowserSession.UpdatedAt = currentTimeInUserTimeZone;
        chattyBrowserSession.UpdatedAtGmt = currentTimeInGmt;
        chattyBrowserSession.Deleted = 0;

        var result = await _context.ChattyBrowserSessions.AddAsync(chattyBrowserSession);
        await _context.SaveChangesAsync();
        return result.Entity;

    }

    public async void DeleteById(int chattyBrowserSessionId)
    {
        var result = await _context.ChattyBrowserSessions.FirstOrDefaultAsync(b => b.Id == chattyBrowserSessionId && b.Deleted == 0);
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
        var result = await _context.ChattyBrowserSessions.FirstOrDefaultAsync(b => b.Id == chattyBrowserSession.Id && b.Deleted == 0);

        if (result == null)
        {
            return null;
        }

        result.SessionUuid = chattyBrowserSession.SessionUuid;

        String userTimeZone = "Asia/Kolkata";
        TimeZoneInfo timeZoneUser = TimeZoneInfo.FindSystemTimeZoneById(userTimeZone);
        DateTime currentTimeInUserTimeZone = TimeZoneInfo.ConvertTime(DateTime.Now, timeZoneUser);

        String gmtTimeZone = "GMT";
        TimeZoneInfo timeZoneGmt = TimeZoneInfo.FindSystemTimeZoneById(gmtTimeZone);
        DateTime currentTimeInGmt = TimeZoneInfo.ConvertTime(DateTime.Now, timeZoneGmt);

        result.UpdatedAt = currentTimeInUserTimeZone;
        result.UpdatedAtGmt = currentTimeInGmt;

        await _context.SaveChangesAsync();

        return result;

    }
}
