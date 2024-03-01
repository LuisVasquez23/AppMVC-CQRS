using Domain.Entities;
using Domain.ViewModels.Persona;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Persona
{
    public interface IPersonaServices
    {
        Task<List<PersonaViewModel>> GetPersonas();
        Task<PersonaViewModel> GetPersonaById(int idPersona);
        Task<bool> CreatePersona(PersonaViewModel model);
        Task<bool> DeletePersona(int IdPersona);
        Task<bool> UpdatePersona(PersonaViewModel model);
    }
}
