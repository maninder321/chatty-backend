using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chatty.ApplicationCore.Entities;

namespace Chatty.Infrastructure.Context;

public class ChattyDbContext : DbContext
{

    public DbSet<ChattyUser> ChattyUsers { get; set; }

    public ChattyDbContext(DbContextOptions<ChattyDbContext> options) : base(options)
    {

    }

}