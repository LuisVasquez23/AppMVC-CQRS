using Domain.Entities;
using Domain.ViewModels.Persona;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.Persona
{
    public class PersonaServices : IPersonaServices
    {

        private readonly IDatabaseService _databaseService;

        public PersonaServices(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public async Task<List<PersonaViewModel>> GetPersonas()
        {
            List<PersonaViewModel> personas = new List<PersonaViewModel>();

            personas = await _databaseService.Personas.Select( x => new PersonaViewModel
            {
                IdPersona = x.IdPersona,
                Nombre = x.Nombre,  
                Apellido = x.Apellido,
                Email = x.Email,
                FechaNacimiento = x.FechaNacimiento.Value.ToShortDateString() ?? "",
            }).ToListAsync();

            return personas;
        }

        public async Task<PersonaViewModel> GetPersonaById(int idPersona)
        {
            PersonaViewModel? persona = null;

            persona = await _databaseService.Personas.Where( x => x.IdPersona == idPersona).Select(x => new PersonaViewModel
                                                        {
                                                            IdPersona = x.IdPersona,
                                                            Nombre = x.Nombre,
                                                            Apellido = x.Apellido,
                                                            Email = x.Email,
                                                            FechaNacimiento = x.FechaNacimiento.Value.ToShortDateString() ?? "",
                                                        }).FirstOrDefaultAsync();

            return persona;
        }

        public async Task<bool> CreatePersona(PersonaViewModel model)
        {
            bool isAdded = false;
            try
            {
                PersonaEntity persona = new PersonaEntity();

                persona.Nombre = model.Nombre;
                persona.Apellido = model.Apellido;
                persona.Email = model.Email;
                persona.FechaNacimiento = model.FechaNacimiento == null ? null : DateTime.Parse(model.FechaNacimiento);

                await _databaseService.Personas.AddAsync(persona);
                isAdded = await _databaseService.SaveAsync();

            }catch (Exception ex)
            {
                isAdded = false;
            }

            return isAdded;
        }

        public async Task<bool> DeletePersona(int IdPersona)
        {
            bool isDeleted = false;
            try
            {
                var persona = await _databaseService.Personas.Where( x=> x.IdPersona == IdPersona).FirstOrDefaultAsync();

                if (persona == null)
                {
                    return isDeleted;
                }

                _databaseService.Personas.Remove(persona);
                return await _databaseService.SaveAsync();

            }
            catch (Exception ex)
            {
                isDeleted = false;
            }

            return isDeleted;
        }

        public async Task<bool> UpdatePersona(PersonaViewModel model)
        {
            var personaEditar = await _databaseService.Personas.Where(x => x.IdPersona == model.IdPersona).FirstOrDefaultAsync();

            if (personaEditar == null)
            {
                return false;
            }

            personaEditar.Nombre = model.Nombre;
            personaEditar.Apellido = model.Apellido;
            personaEditar.Email = model.Email;
            personaEditar.FechaNacimiento = model.FechaNacimiento == null ? personaEditar.FechaNacimiento 
                                                                          : DateTime.Parse(model.FechaNacimiento);

            _databaseService.Personas.Update(personaEditar);
            return await _databaseService.SaveAsync();
        }
    }
}
