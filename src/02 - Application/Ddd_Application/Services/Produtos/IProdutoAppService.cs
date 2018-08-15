using Ddd.Application.Base.Dto;
using Ddd.Application.Services.Produtos.Dtos;

namespace Ddd.Application.Services.Produtos
{
    public interface IProdutoAppService
    {
        ProdutoFormDto Cadastrar(ProdutoFormDto formDto);

        ProdutoFormDto CarregarForm(int id);

        GridDto<ProdutoGridDto> CarregarGrid(int numeroDaPagina, int registrosPorPagina, string filtro);

        ProdutoFormDto Editar(ProdutoFormDto formDto);

        ExcluirDto Excluir(int id);
    }
}