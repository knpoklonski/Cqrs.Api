using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CqrsApi.Domain.Infrastructure.Commands;
using CqrsApi.Domain.Infrastructure.Queries;
using CqrsApi.Domain.Orders;
using CqrsApi.Domain.Orders.Commands;
using CqrsApi.Domain.Orders.Queries;
using CqrsApi.Infrastructure;
using CqrsApi.Models.Orders;
using Microsoft.AspNetCore.Mvc;

namespace CqrsApi.Controllers
{
    [Route("api/customers/{customerId}/[controller]")]
    [ApiController]
    public class OrdersController : BaseController
    {
        private readonly ICommandsDispatcher _commandsDispatcher;

        private readonly IQueriesDispatcher _queryDispatcher;

        public OrdersController(IQueriesDispatcher queryDispatcher, ICommandsDispatcher commandsDispatcher)
        {
            _commandsDispatcher = commandsDispatcher ?? throw new ArgumentNullException(nameof(commandsDispatcher));
            _queryDispatcher = queryDispatcher ?? throw new ArgumentNullException(nameof(queryDispatcher));
        }

        [HttpGet]
        public async Task<CollectionResult<Order>> Get(int customerId, int? top, int? skip)
        {
            var query = new GetManyOrdersQuery(customerId, top, skip);
            var orders = await _queryDispatcher.ExecuteAsync<IEnumerable<Order>, GetManyOrdersQuery>(query);

            return new CollectionResult<Order>(orders, query.Skip, query.Top, HttpContext.RequestedUrl());
        }

        [HttpPost]
        public async Task Post(int customerId, [FromBody] OrderEditModel editModel)
        {
            var createCommand = new CreateOrderCommand(customerId, editModel.Price);
            await _commandsDispatcher.ExecuteAsync(createCommand);
        }
    }
}