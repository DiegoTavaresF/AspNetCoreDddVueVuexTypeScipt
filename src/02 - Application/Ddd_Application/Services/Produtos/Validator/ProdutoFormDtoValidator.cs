using Ddd.Application.Services.Produtos.Dtos;
using FluentValidation;

namespace Ddd.Application.Services.Produtos.Validator
{
    public class ProdutoFormDtoValidator : AbstractValidator<ProdutoFormDto>
    {
        public ProdutoFormDtoValidator()
        {
            RuleFor(dto => dto.Nome)
                .NotEmpty().WithMessage("Nome é obrigatório.");

            RuleFor(dto => dto.PrecoDeVenda)
                .GreaterThan(0).WithMessage("Preço de venda deve ser maior que zero.");
        }
    }
}