namespace CqrsApi.Domain.Infrastructure.Commands
{
    using System.Threading.Tasks;

    public interface ICommandHandlerAsync<in TCommand, TCommandResult> where TCommand : ICommand
    {
        Task<TCommandResult> ExecuteAsync(TCommand command);
    }
}