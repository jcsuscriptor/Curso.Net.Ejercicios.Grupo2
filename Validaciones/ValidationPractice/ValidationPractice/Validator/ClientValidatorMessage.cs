using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidationPractice.Model;

namespace ValidationPractice.Validator
{
    public class ClientValidatorMessage : AbstractValidator<Client>
    {
        //Personalizar mensaje de validacion
        public ClientValidatorMessage()
        {
            RuleFor(client => client.Id).GreaterThan(10)
                    .WithMessage("El identificador debe ser mayor a {ComparisonValue}. Actualmente tu valor es {PropertyValue}");

            RuleFor(client => client.Name).NotNull()
                    .WithMessage("El valor de la propiedad {PropertyName} no puede ser nulo");
        }
    }
}
