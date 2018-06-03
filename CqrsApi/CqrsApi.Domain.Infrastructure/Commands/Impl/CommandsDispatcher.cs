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

        public void Execute<TCommand>(TCommand command) where TCommand : ICommand
        {
            _commandHandlersFactory.CreateHandler<TCommand>().Execute(command);
        }

        public Task ExecuteAsync<TCommand>(TCommand command)
            where TCommand : ICommand
        {
            return _commandHandlersFactory.CreateAsyncHandler<TCommand>().Execute(command);
        }
    }
}