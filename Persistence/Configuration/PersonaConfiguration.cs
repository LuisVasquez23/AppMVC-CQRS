using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configuration
{
    public class PersonaConfiguration
    {

        public PersonaConfiguration(EntityTypeBuilder<PersonaEntity> entityBuilder) {
            entityBuilder.HasKey(x => x.IdPersona);
            entityBuilder.Property(x => x.Nombre).IsRequired();
            entityBuilder.Property(x => x.Apellido).IsRequired();
            entityBuilder.Property(x => x.Email).IsRequired();
            entityBuilder.Property(x => x.FechaNacimiento);
        }

    }
}
