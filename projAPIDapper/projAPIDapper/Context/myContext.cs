using Microsoft.EntityFrameworkCore;
using projAPIDapper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projAPIDapper.Context
{
    public class myContext:DbContext
    {
        public myContext(DbContextOptions<myContext> options) : base(options)
        {

        }
        public DbSet<PresenceBook> PresenceBooks { get; set; }
    }
}
