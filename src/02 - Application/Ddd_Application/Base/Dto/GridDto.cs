using System.Collections.Generic;

namespace Ddd.Application.Base.Dto
{
    public class GridDto<T> where T : class
    {
        public IList<T> Itens { get; set; }
        public PaginaDto Pagina { get; set; }
        public int TotalDeItensEncontrados { get; set; }
    }
}