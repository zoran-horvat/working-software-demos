using System;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Demo.Infrastructure
{
    static class ContentContextExtensions
    {
        public static Lazy<IContentGateway> ToLazyContext(this IContentGatewayFactory factory, PageModel page) =>
            new Lazy<IContentGateway>(() => factory.Create(page.User.Claims.First(claim => claim.Type == ClaimTypes.NameIdentifier).Value));
    }
}