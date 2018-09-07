using Ddd.Application.Services.Tarefas.Dtos;
using Ddd.Domain.Base;
using FluentValidation;

namespace Ddd.Application.Services.Tarefas.Validator
{
    public class TarefaFormDtoValidator : AbstractValidator<TarefaFormDto>
    {
        public TarefaFormDtoValidator()
        {
            RuleFor(dto => dto.Titulo)
                .NotEmpty()
                    .WithMessage("Título é obrigatório.")
                .Length(ColumnLengths.TarefaTituloMinLength, ColumnLengths.TarefaTituloMaxLength)
                    .WithMessage($"Título deve ter entre {ColumnLengths.TarefaTituloMinLength} e {ColumnLengths.TarefaTituloMaxLength} caracteres.");

            RuleFor(dto => dto.Descricao)
                .MaximumLength(ColumnLengths.TarefaDescricaoMaxLength)
                    .WithMessage($"Descrição pode ter no máximo {ColumnLengths.TarefaDescricaoMaxLength} caracteres.");
        }
    }
}