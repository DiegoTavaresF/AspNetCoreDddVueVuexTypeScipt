using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Security.Claims;

namespace Ddd.Domain.Base
{
    public class UsuarioAutenticado : IUsuarioAutenticado
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public UsuarioAutenticado(IHttpContextAccessor accessor)
        {
            _contextAccessor = accessor;
        }

        public string Id => _contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        public string Name => _contextAccessor.HttpContext.User.Identity.Name;

        public IEnumerable<Claim> GetClaimsIdentity()
        {
            return _contextAccessor.HttpContext.User.Claims;
        }

        public bool IsAuthenticated()
        {
            return _contextAccessor.HttpContext.User.Identity.IsAuthenticated;
        }
    }
}