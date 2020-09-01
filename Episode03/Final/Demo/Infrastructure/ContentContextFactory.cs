using Demo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Demo.Infrastructure
{
    public class ContentContextFactory : IContentGatewayFactory
    {
        private string ConnectionString { get; }
        private ILoggerFactory LoggerFactory { get; }

        public ContentContextFactory(string connectionString, ILoggerFactory loggerFactory)
        {
            this.ConnectionString = connectionString;
            this.LoggerFactory = loggerFactory;
        }

        public IContentGateway Create(UserRef owner) => 
            new ContentContext(new DbContextOptionsBuilder<ContentContext>().UseSqlServer(this.ConnectionString).UseLoggerFactory(this.LoggerFactory).Options, owner);
    }
}