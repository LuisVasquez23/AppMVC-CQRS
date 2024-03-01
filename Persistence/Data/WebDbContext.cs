using Application.Services;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Configuration;

namespace Persistence.Data
{
    public class WebDbContext : DbContext , IDatabaseService
    {

        public WebDbContext(DbContextOptions options) : base(options) { 
        
        }

        public DbSet<PersonaEntity> Personas {  get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            EntityConfiguration(modelBuilder);
        }

        private void EntityConfiguration(ModelBuilder modelBuilder)
        {
            new PersonaConfiguration(modelBuilder.Entity<PersonaEntity>());
        }

        public async Task<bool> SaveAsync()
        {
            return await SaveChangesAsync() > 0;
        }
    }
}
