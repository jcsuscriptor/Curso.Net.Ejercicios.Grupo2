using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidationPractice.Model;

namespace ValidationPractice.Validator
{
    public class ClientValidatorEncadenar : AbstractValidator<Client>
    {
        //Encadenar validaciones
        public ClientValidatorEncadenar()
        {
            RuleFor(client => client.Id)
                .GreaterThan(0)
                .LessThan(50)
                .WithMessage("El identificador debe ser mayor a 0 y menor a 50");
            
            
            RuleFor(client => client.Name)
                .NotNull()
                .NotEqual("foo")
                .WithMessage("El valor de Nombre no puede ser nulo y no debe ser igual a foo");
        }
    }
}
