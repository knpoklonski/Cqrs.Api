using System.Collections.Generic;
using System.Threading.Tasks;
using CqrsApi.Domain.Customers;
using CqrsApi.Domain.Customers.Queries;
using CqrsApi.Domain.Infrastructure.Queries;
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
            var criterion = new GetManyQuery(top, skip);
            var customers = await _queryDispatcher.ExecuteAsync<IEnumerable<Customer>, GetManyQuery>(criterion);

            return new CollectionResult<Customer>(customers, criterion.Top, criterion.Skip, HttpContext.RequestedUrl());
        }

        [HttpGet("{id}")]
        public async Task<CustomerDetails> Get(int id)
        {
            var criterion = new FindByIdQuery(id);
            return await _queryDispatcher.ExecuteAsync<CustomerDetails, FindByIdQuery>(criterion);
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
