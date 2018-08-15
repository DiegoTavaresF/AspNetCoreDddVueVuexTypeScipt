using System.Collections.Generic;
using System.Security.Claims;

namespace Ddd.Domain.Base
{
    public interface IUsuarioAutenticado
    {
        string Id { get; }
        string Name { get; }

        IEnumerable<Claim> GetClaimsIdentity();

        bool IsAuthenticated();
    }
}