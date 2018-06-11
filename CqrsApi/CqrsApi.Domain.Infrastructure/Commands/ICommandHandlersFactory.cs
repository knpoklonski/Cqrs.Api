namespace CqrsApi.Domain.Infrastructure.Commands
{
    public interface ICommandHandlersFactory
    {
        ICommandHandler<TCommand, TCommandResult> CreateHandler<TCommand, TCommandResult>() where TCommand : ICommand;
        ICommandHandlerAsync<TCommand, TCommandResult> CreateAsyncHandler<TCommand, TCommandResult>() where TCommand : ICommand;
    }
}