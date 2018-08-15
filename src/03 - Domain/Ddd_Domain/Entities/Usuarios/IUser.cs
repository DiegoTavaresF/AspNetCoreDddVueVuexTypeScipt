using System.Collections.Generic;
using System.Security.Claims;

namespace Ddd.Domain.Entities.Usuarios
{
    public interface IUser
    {
        string Name { get; }

        IEnumerable<Claim> GetClaimsIdentity();

        bool IsAuthenticated();
    }
}