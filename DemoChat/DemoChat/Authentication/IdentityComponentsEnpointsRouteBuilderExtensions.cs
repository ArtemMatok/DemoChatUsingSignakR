using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Routing;
using System.Reflection.Metadata;
using System.Security.Claims;

namespace DemoChat.Authentication
{
    public static class IdentityComponentsEnpointsRouteBuilderExtensions
    {
        internal static IEndpointConventionBuilder MapAdditionalIdentityEnpoints(this IEndpointRouteBuilder endpoints)
        {
            var accountGroup = endpoints.MapGroup("/Account");
            accountGroup.MapPost("/Logout", async (ClaimsPrincipal user, SignInManager<AppUser> signInManager) =>
            {
                await signInManager.SignOutAsync();
                return TypedResults.LocalRedirect("/");

            });
            return accountGroup;
        }
    }
}
