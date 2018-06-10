using System.Threading.Tasks;

namespace CqrsApi.Domain.Infrastructure.Commands
{
    public interface IValidationHandler<TCommand>
    {
        Task Validate(TCommand command);
    }
}