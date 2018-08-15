using Ddd.Application.Base.Dto;

namespace Ddd.Application.Services.Produtos.Dtos
{
    public class ProdutoFormDto : MainDtoError
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal PrecoDeVenda { get; set; }
    }
}