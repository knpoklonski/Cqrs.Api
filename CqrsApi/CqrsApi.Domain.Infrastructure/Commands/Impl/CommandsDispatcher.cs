using System;
using System.Threading.Tasks;

namespace CqrsApi.Domain.Infrastructure.Commands.Impl
{
    public class CommandsDispatcher : ICommandsDispatcher
    {
        private readonly ICommandHandlersFactory _commandHandlersFactory;

        public CommandsDispatcher(ICommandHandlersFactory commandHandlersFactory)
        {
            if (commandHandlersFactory == null)
                throw new ArgumentNullException(nameof(commandHandlersFactory));

            _commandHandlersFactory = commandHandlersFactory;
        }

        public TCommandResult Execute<TCommand, TCommandResult>(TCommand command) where TCommand : ICommand
        {
           return _commandHandlersFactory.CreateHandler<TCommand, TCommandResult>().Execute(command);
        }

        public Task<TCommandResult> ExecuteAsync<TCommand, TCommandResult>(TCommand command)
            where TCommand : ICommand
        {
            return _commandHandlersFactory.CreateAsyncHandler<TCommand, TCommandResult>().ExecuteAsync(command);
        }
    }
}