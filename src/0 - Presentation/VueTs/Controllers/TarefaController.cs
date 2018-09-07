using Ddd.Application.Base.Dto;
using Ddd.Application.Services.Tarefas;
using Ddd.Application.Services.Tarefas.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace VueTs.Controllers
{
    [Route("api/[controller]")]
    public class TarefaController : Controller
    {
        private readonly ITarefaAppService _tarefaAppService;

        public TarefaController(ITarefaAppService tarefaAppService)
        {
            this._tarefaAppService = tarefaAppService;
        }

        [HttpPost("[action]")]
        public TarefaFormDto Cadastrar([FromBody] TarefaFormDto tarefaFormDto)
        {
            var result = _tarefaAppService.Cadastrar(tarefaFormDto);

            return result;
        }

        [HttpGet("[action]")]
        public TarefaFormDto CarregarForm(long id)
        {
            var dto = _tarefaAppService.CarregarForm(id);

            return dto;
        }

        [HttpGet("[action]")]
        public GridDto<TarefaGridDto> CarregarGrid(int paginaAtual = 0, int itensPorPagina = 10, string filtro = null,
             TarefaGridFiltroAvancadoDto filtroAvancado = null, bool usarFiltroAvancado = false)
        {
            var gridDto = _tarefaAppService.CarregarGrid(paginaAtual, itensPorPagina, filtro, usarFiltroAvancado ? filtroAvancado : null);

            return gridDto;
        }

        [HttpPut("[action]")]
        public TarefaFormDto Editar([FromBody] TarefaFormDto tarefaFormDto)
        {
            var result = _tarefaAppService.Editar(tarefaFormDto);

            return result;
        }

        [HttpDelete("[action]")]
        public ExcluirDto Excluir(long id)
        {
            var dto = _tarefaAppService.Excluir(id);

            return dto;
        }
    }
}