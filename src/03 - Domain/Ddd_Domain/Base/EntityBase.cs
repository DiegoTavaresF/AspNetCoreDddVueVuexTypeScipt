using System;

namespace Ddd.Domain.Base
{
    public class EntityBase : MainError
    {
        public DateTime? DataDaUltimaAlteracao { get; set; }
        public DateTime DataDeCadastro { get; set; }
        public bool Excluido { get; set; }
        public long Id { get; set; }
    }
}