using Demo.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo.Infrastructure
{
    public class SecureContentContextFactory : IContentGatewayFactory
    {
        private DbContextOptions<SecureContentContext> Options { get; }

        public SecureContentContextFactory(DbContextOptions<SecureContentContext> options)
        {
            this.Options = options;
        }

        public IContentGateway Create(UserRef owner) => 
            new SecureContentContext(this.Options, owner);
    }
}