namespace CqrsApi.Domain.Infrastructure.Commands
{
    public interface ICommandHandler<in TCommand, TCommandResult> where TCommand : ICommand
    {
        TCommandResult Execute(TCommand command);
    }
}