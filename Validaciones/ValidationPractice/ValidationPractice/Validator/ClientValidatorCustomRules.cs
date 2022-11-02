using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidationPractice.Model;

namespace ValidationPractice.Validator
{

    public class ClientValidatorCustomRules : AbstractValidator<Client>
    {
        //Reglas personalizadas
        public ClientValidatorCustomRules()
        {
            RuleFor(client => client)
                .Must((client) => ValidarDatosPersonales(client))
                .WithMessage("El nombre y apellido no pueden ser nulos ni vacios");

            RuleFor(c => c.Name).
                Must((name) => ValidarName(name))
                .WithMessage("Palabras no permitidas");

            RuleFor(client => client.Address)
                .NotNull()
                .SetValidator(new AddressValidator());

        }

        public bool ValidarName(string name)
        {
            var paralabrasNoPermitidas = new[] { "Foo","Bar" };

            if (paralabrasNoPermitidas.Contains(name)) {
                return false;   
            }
             
            return true;
        }

        public bool ValidarDatosPersonales(Client client)
        {
            if(string.IsNullOrEmpty(client.Name))
            {
                return false;
            }

            if(string.IsNullOrEmpty(client.LastName))
            {
                return false;
            }

            return true;
        }
    }
}
