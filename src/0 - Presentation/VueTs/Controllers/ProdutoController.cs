using Ddd.Application.Base.Dto;
using Ddd.Application.Services.Produtos;
using Ddd.Application.Services.Produtos.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace VueTs.Controllers
{
    [Route("api/[controller]")]
    public class ProdutoController : Controller
    {
        private readonly IProdutoAppService _produtoAppService;

        public ProdutoController(IProdutoAppService produtoAppService)
        {
            this._produtoAppService = produtoAppService;
        }

        [HttpPost("[action]")]
        public ProdutoFormDto Cadastrar([FromBody] ProdutoFormDto produtoFormDto)
        {
            var result = _produtoAppService.Cadastrar(produtoFormDto);

            return result;
        }

        [HttpGet("[action]")]
        public ProdutoFormDto CarregarForm(int id)
        {
            var dto = _produtoAppService.CarregarForm(id);

            return dto;
        }

        [HttpGet("[action]")]
        public GridDto<ProdutoGridDto> CarregarGrid(int paginaAtual = 0, int itensPorPagina = 10, string filtro = null)
        {
            var gridDto = _produtoAppService.CarregarGrid(paginaAtual, itensPorPagina, filtro);

            return gridDto;
        }

        [HttpPost("[action]")]
        public ProdutoFormDto Editar([FromBody] ProdutoFormDto produtoFormDto)
        {
            var result = _produtoAppService.Editar(produtoFormDto);

            return result;
        }

        [HttpDelete("[action]")]
        public ExcluirDto Excluir(int id)
        {
            var dto = _produtoAppService.Excluir(id);

            return dto;
        }
    }
}