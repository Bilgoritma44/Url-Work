using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Deneme.Models
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=LAPTOPSN-PF22HQ\\DENEME;database=IndataLink2;integrated security=true");
        }
        public DbSet<Link> Links { get; set; }

    }
}