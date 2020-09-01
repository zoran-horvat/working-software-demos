using Demo.Models;

namespace Demo.Infrastructure
{
    public interface IContentGatewayFactory
    {
        IContentGateway Create(UserRef owner);
    }
}