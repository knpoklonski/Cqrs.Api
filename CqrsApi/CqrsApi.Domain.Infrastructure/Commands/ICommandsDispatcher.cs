using System.Threading.Tasks;

namespace CqrsApi.Domain.Infrastructure.Commands
{
    public interface ICommandsDispatcher
    {
        TCommandResult Execute<TCommand, TCommandResult>(TCommand command) where TCommand : ICommand;
        Task<TCommandResult> ExecuteAsync<TCommand, TCommandResult>(TCommand command) where TCommand : ICommand;
    }
}