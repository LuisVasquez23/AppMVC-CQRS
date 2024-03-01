using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public interface IDatabaseService
    {
        DbSet<PersonaEntity> Personas { get; set; }

        Task<bool> SaveAsync();
    }
}
