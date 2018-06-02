using System.Threading.Tasks;

namespace CqrsApi.Domain.Infrastructure.Commands
{
    public interface ICommandsDispatcher
    {
        void Execute<TCommandContext>(TCommandContext commandContext) where TCommandContext : ICommandContext;
        Task ExecuteAsync<TCommandContext>(TCommandContext commandContext) where TCommandContext : ICommandContext;
    }
}