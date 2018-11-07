using Ddd.Application.Base.Dto;
using Ddd.Application.Services.Tarefas;
using Ddd.Application.Services.Tarefas.Dtos;
using Ddd.Domain.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace VueTs.Controllers
{
    [Route("api/[controller]")]
    public class TarefaController : Controller
    {
        private readonly ITarefaAppService _tarefaAppService;
        private readonly IUnitOfWork _unitOfWork;

        public TarefaController(ITarefaAppService tarefaAppService, IUnitOfWork unitOfWork)
        {
            _tarefaAppService = tarefaAppService;
            _unitOfWork = unitOfWork;
        }

        [HttpPost("[action]")]
        public TarefaFormDto Cadastrar([FromBody] TarefaFormDto tarefaFormDto)
        {
            var result = _tarefaAppService.Cadastrar(tarefaFormDto);
            var wowResult = _unitOfWork.Commit();

            if (!wowResult)
            {
                var tarefaForm = new TarefaFormDto();
                tarefaForm.Erros.Add("Erro ao salvar dados.");

                return tarefaForm;
            }

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
            var wowResult = _unitOfWork.Commit();

            if (!wowResult)
            {
                var tarefaForm = new TarefaFormDto();
                tarefaForm.Erros.Add("Erro ao salvar dados.");

                return tarefaForm;
            }

            return result;
        }

        [HttpDelete("[action]")]
        public ExcluirDto Excluir(long id)
        {
            var result = _tarefaAppService.Excluir(id);
            var wowResult = _unitOfWork.Commit();

            if (!wowResult)
            {
                return new ExcluirDto
                {
                    Id = id,
                    Erro = "Erro ao salvar dados"
                };
            }

            return result;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _unitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}