namespace CqrsApi.Domain.Infrastructure.Commands
{
    public interface IValidationHandler<TCommand>
    {
        void Validate(TCommand command);
    }
}