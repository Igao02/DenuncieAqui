using DenuncieAqui.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DenuncieAqui.Infrastructure.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {

        public DbSet<Capa> Capas { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<Reports> Reports { get; set; }

        public DbSet<Comments> Comments { get; set; }

        public DbSet<Likes> Likes { get; set; }

        public DbSet<Images> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}