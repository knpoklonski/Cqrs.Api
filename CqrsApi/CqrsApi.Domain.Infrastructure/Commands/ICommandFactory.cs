namespace CqrsApi.Domain.Infrastructure.Commands
{
    public interface ICommandsFactory
    {
        ICommand<TCommandContext> CreateCommand<TCommandContext>() where TCommandContext : ICommandContext;
        IAsyncCommand<TCommandContext> CreateAsyncCommand<TCommandContext>() where TCommandContext : ICommandContext;
    }
}