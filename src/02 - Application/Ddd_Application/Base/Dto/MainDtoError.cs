using System.Collections.Generic;
using System.Linq;

namespace Ddd.Application.Base.Dto
{
    public class MainDtoError
    {
        public MainDtoError()
        {
            Erros = new List<string>();
            ValidationErros = new List<ValidationFailureDto>();
        }

        public IList<string> Erros { get; set; }

        public IList<ValidationFailureDto> ValidationErros { get; set; }

        public bool IsValid()
        {
            return !ValidationErros.Any() && !Erros.Any();
        }
    }
}