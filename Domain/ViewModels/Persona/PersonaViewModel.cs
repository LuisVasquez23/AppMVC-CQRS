
using System.ComponentModel.DataAnnotations;

namespace Domain.ViewModels.Persona
{
    public class PersonaViewModel
    {
        public int IdPersona { get; set; }

        [Required(ErrorMessage = "El campo 'Nombre' es obligatorio.")]
        public string? Nombre { get; set; }
        [Required(ErrorMessage = "El campo 'Apellido' es obligatorio.")]
        public string? Apellido { get; set; }
        [Required(ErrorMessage = "El campo 'Email' es obligatorio.")]
        public string? Email { get; set; }
        public string? FechaNacimiento { get; set; }
    }
}
