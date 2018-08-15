using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Ddd.Domain.Base
{
    public class MainError
    {
        public MainError()
        {
            Errors = new List<string>();
        }

        [NotMapped]
        public IList<string> Errors { get; set; }

        public void AddError(string error)
        {
            if (!Errors.Contains(error))
            {
                Errors.Add(error);
            }
        }

        public bool IsValid()
        {
            return !Errors.Any();
        }
    }
}