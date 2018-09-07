using Ddd.Application.Base.Dto;
using Ddd.Application.Services.Tarefas.Dtos;

namespace Ddd.Application.Services.Tarefas
{
    public interface ITarefaAppService
    {
        TarefaFormDto Cadastrar(TarefaFormDto formDto);

        TarefaFormDto CarregarForm(long id);

        GridDto<TarefaGridDto> CarregarGrid(int numeroDaPagina, int registrosPorPagina, string filtro, TarefaGridFiltroAvancadoDto filtroAvancado = null);

        TarefaFormDto Editar(TarefaFormDto formDto);

        ExcluirDto Excluir(long id);
    }
}