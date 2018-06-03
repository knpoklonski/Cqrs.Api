namespace CqrsApi.Domain.Infrastructure.Commands
{
    public interface ICommandHandlersFactory
    {
        ICommandHandler<TCommand> CreateHandler<TCommand>() where TCommand : ICommand;
        ICommandHandlerAsync<TCommand> CreateAsyncHandler<TCommand>() where TCommand : ICommand;
    }
}