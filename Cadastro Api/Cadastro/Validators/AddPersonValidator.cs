using Cadastro.Models;
using FluentValidation;
using System;

namespace Cadastro.Validators
{
    public class AddPersonValidator : AbstractValidator<Person>
    {
        public AddPersonValidator()
        {
            RuleFor(m => m.Name)
                .NotEmpty()
                    .WithMessage("Nome não pode ser vazio")
                .MinimumLength(5)
                    .WithMessage("Nome menor que 5 caracteres")
                .MaximumLength(50)
                    .WithMessage("Nome maior que 50 caracteres");

            RuleFor(m => m.BirthDate)
                .NotEmpty()
                    .WithMessage("Infome a data de nascimento")
                .LessThan(DateTime.Now.Date)
                    .WithMessage("Data de Nascimento não pode ser maior que a data atual")
                .Must(MaiorDeIdade)
                    .WithMessage("A pessoa deve ser maior de 18 anos");

            RuleFor(m => m.Genre)
                .NotEmpty()
                    .WithMessage("Sexo não pode ser vazio")
                .Must(d => d == "M" || d == "F")
                    .WithMessage("Favor digitar M ou F para o Sexo");
            
            RuleFor(m => m.Cpf)
                .NotEmpty()
                    .WithMessage("CPF não pode ser vazio")
                .Must(d => d.IsValidDocument())
                    .WithMessage("Documento inválido");
        }
        private static bool MaiorDeIdade(DateTime birthDate) => birthDate <= DateTime.Now.AddYears(-18);
    }
}
