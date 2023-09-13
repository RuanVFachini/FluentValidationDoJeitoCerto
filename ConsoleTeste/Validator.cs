using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTeste
{
    public class Validator : AbstractValidator<Li>
    {
        public Validator()
        {
            RuleFor(x => x)
                .Cascade(CascadeMode.Stop)
                .CustomAsync(async(li, context, token) =>
            {
                context.AddFailure(new FluentValidation.Results.ValidationFailure()
                {
                    ErrorMessage = "Validação 1 falhou",
                    PropertyName = "Numero",
                    CustomState = new
                    {
                        QualquerCoisa = 1
                    }
                });
            }).CustomAsync(async(li, context, token) =>
            {
                context.AddFailure(new FluentValidation.Results.ValidationFailure()
                {
                    ErrorMessage = "Validação 2 falhou",
                    PropertyName = "Numero",
                    CustomState = new
                    {
                        QualquerCoisa = 2
                    }
                });
            });
        }
    }
}
