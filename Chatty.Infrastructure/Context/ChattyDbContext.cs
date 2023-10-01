using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatty.Infrastructure.Context;

public class ChattyDbContext : DbContext
{

    public ChattyDbContext(DbContextOptions<ChattyDbContext> options) : base(options)
    {

    }

}