namespace CqrsApi.Domain.Infrastructure.Commands
{
    public interface ICommand<in TCommandContext> where TCommandContext : ICommandContext
    {
        void Execute(TCommandContext commandContext);
    }
}