using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace News_Project.Models
{
    public class NewsDbContext:DbContext
    {
        public NewsDbContext(DbContextOptions<NewsDbContext> options):base(options)
        {

        }

        public DbSet<News> News { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<TeamMember> TeamMembers { get; set; }
        public DbSet<ContactUS> Contacts { get; set; }

    }
}
