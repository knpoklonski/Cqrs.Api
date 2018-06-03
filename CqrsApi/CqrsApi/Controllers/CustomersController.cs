using System.Collections.Generic;
using System.Threading.Tasks;
using CqrsApi.Domain.Customers;
using CqrsApi.Domain.Infrastructure.Queries;
using CqrsApi.Domain.Shared.Queries;
using CqrsApi.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace CqrsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : BaseController
    {
        private readonly IQueriesDispatcher _queryDispatcher;

        public CustomersController(IQueriesDispatcher queryDispatcher)
        {
            _queryDispatcher = queryDispatcher;
        }

        [HttpGet]
        public async Task<CollectionResult<Customer>> Get(int? top, int? skip)
        {
            var query = new GetManyQuery<Customer>(top, skip);
            var customers = await _queryDispatcher.ExecuteAsync<IEnumerable<Customer>, GetManyQuery<Customer>>(query);

            return new CollectionResult<Customer>(customers, query.Top, query.Skip, HttpContext.RequestedUrl());
        }

        [HttpGet("{id}")]
        public async Task<CustomerDetails> Get(int id)
        {
            var query = new FindByIdQuery<CustomerDetails>(id);
            return await _queryDispatcher.ExecuteAsync<CustomerDetails, FindByIdQuery<CustomerDetails>>(query);
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
