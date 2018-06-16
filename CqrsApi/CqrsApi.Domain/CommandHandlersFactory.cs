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

        public ICommandHandler<TCommand> CreateHandler<TCommand>() where TCommand : ICommand
        {
            return (ICommandHandler<TCommand>) _serviceProvider.GetService(typeof(ICommandHandler<TCommand>));
        }

        public ICommandHandlerAsync<TCommand> CreateAsyncHandler<TCommand>() where TCommand : ICommand
        {
            return (ICommandHandlerAsync<TCommand>)_serviceProvider.GetService(typeof(ICommandHandlerAsync<TCommand>));
        }
    }
}