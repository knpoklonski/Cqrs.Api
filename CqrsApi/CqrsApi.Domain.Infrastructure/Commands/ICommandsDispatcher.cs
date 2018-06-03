using System.Threading.Tasks;

namespace CqrsApi.Domain.Infrastructure.Commands
{
    public interface ICommandsDispatcher
    {
        void Execute<TCommand>(TCommand command) where TCommand : ICommand;
        Task ExecuteAsync<TCommand>(TCommand command) where TCommand : ICommand;
    }
}