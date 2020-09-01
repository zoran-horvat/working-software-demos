using System;
using System.Linq;
using System.Security.Claims;
using Demo.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Demo.Infrastructure
{
    static class SecureGatewayExtensions
    {
        public static Lazy<IContentGateway> ToLazyContentGateway(this IContentGatewayFactory factory, PageModel page) =>
            new Lazy<IContentGateway>(() =>
                factory.Create(
                    new UserRef(page.User.Claims.First(claim => claim.Type == ClaimTypes.NameIdentifier).Value)));
    }
}