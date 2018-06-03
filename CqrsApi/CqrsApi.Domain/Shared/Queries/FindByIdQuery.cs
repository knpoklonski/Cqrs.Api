using CqrsApi.Domain.Infrastructure.Queries;

namespace CqrsApi.Domain.Shared.Queries
{
    public class FindByIdQuery<TResult> : IQuery<TResult>
    {
        public FindByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}