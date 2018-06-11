using System;
using CqrsApi.Domain.Infrastructure.Commands;

namespace CqrsApi.Domain
{
    public class CommandHandlersFactory : ICommandHandlersFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public CommandHandlersFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public ICommandHandler<TCommand, TCommandResult> CreateHandler<TCommand, TCommandResult>() where TCommand : ICommand
        {
            return (ICommandHandler<TCommand, TCommandResult>) _serviceProvider.GetService(typeof(ICommandHandler<TCommand, TCommandResult>));
        }

        public ICommandHandlerAsync<TCommand, TCommandResult> CreateAsyncHandler<TCommand, TCommandResult>() where TCommand : ICommand
        {
            return (ICommandHandlerAsync<TCommand, TCommandResult>)_serviceProvider.GetService(typeof(ICommandHandlerAsync<TCommand, TCommandResult>));
        }
    }
}