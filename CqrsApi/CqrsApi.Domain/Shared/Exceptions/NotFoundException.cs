namespace CqrsApi.Domain.Shared.Exceptions
{
    public class NotFoundException : CqrsApiApplicationException
    {
        public NotFoundException(int id) : base($"Resource with id={id} is not found")
        {
        }
    }
}