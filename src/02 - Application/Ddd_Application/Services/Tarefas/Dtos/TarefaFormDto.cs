using Ddd.Application.Base.Dto;

namespace Ddd.Application.Services.Tarefas.Dtos
{
    public class TarefaFormDto : MainDtoError
    {
        public bool Concluido { get; set; }
        public string Descricao { get; set; }
        public long Id { get; set; }
        public string Titulo { get; set; }
    }
}