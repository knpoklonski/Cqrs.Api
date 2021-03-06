﻿namespace CqrsApi.Domain.Infrastructure.Commands
{
    using System.Threading.Tasks;

    public interface ICommandHandlerAsync<in TCommand> where TCommand : ICommand
    {
        Task ExecuteAsync(TCommand command);
    }
}