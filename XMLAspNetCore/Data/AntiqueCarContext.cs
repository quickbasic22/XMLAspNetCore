using Microsoft.EntityFrameworkCore;
using XMLAspNetCore.Models;
using XMLAspNetCore.Data;

namespace XMLAspNetCore.Data
{
    public class AntiqueCarContext : DbContext
    {
        public AntiqueCarContext(DbContextOptions options) : base(options)
        {
        }

        protected AntiqueCarContext()
        {
        }


        public virtual DbSet<Advertisement> AntiqueCarAdvertiments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=ConnectionStrings:AntiqueCarContext");
            }
        }

    }
}
