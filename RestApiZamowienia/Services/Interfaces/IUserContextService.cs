using System.Security.Claims;

namespace RestApiZamowienia.Services.Interfaces;

public interface IUserContextService
{
    ClaimsPrincipal User { get; }
    Guid? GetUserId { get; }
}