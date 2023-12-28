using System.Security.Claims;

namespace RestApiZamowienia.Services.Interfaces;

public interface IUserContextService
{
    ClaimsPrincipal User { get; }
    int? GetUserId { get; }
}