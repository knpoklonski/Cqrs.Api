using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CqrsApi.Domain.Customers;
using CqrsApi.Domain.Customers.Commands;
using CqrsApi.Domain.Infrastructure.Commands;
using CqrsApi.Domain.Infrastructure.Queries;
using CqrsApi.Domain.Shared;
using CqrsApi.Domain.Shared.Exceptions;
using CqrsApi.Domain.Shared.Queries;
using CqrsApi.Infrastructure;
using CqrsApi.Models.Customers;
using Microsoft.AspNetCore.Mvc;

namespace CqrsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : BaseController
    {
        private readonly ICommandsDispatcher _commandsDispatcher;
        private readonly IQueriesDispatcher _queryDispatcher;

        public CustomersController(IQueriesDispatcher queryDispatcher, ICommandsDispatcher commandsDispatcher)
        {
            _queryDispatcher = queryDispatcher ?? throw new ArgumentNullException(nameof(queryDispatcher));
            _commandsDispatcher = commandsDispatcher ?? throw new ArgumentNullException(nameof(commandsDispatcher));
        }

        [HttpGet]
        public async Task<CollectionResult<CustomerResource>> Get(int? top, int? skip)
        {
            var query = new GetManyQuery<Customer>(top, skip);
            var customers = await _queryDispatcher.ExecuteAsync<IEnumerable<Customer>, GetManyQuery<Customer>>(query);
            var resources = customers.Select(x => new CustomerResource
            {
                Id = x.Id,
                Href = HttpContext.GetHref(x.Id)
            }).ToArray();

            return new CollectionResult<CustomerResource>(resources, query.Skip, query.Top, HttpContext.RequestedUrl());
        }

        [HttpGet("{id}")]
        public async Task<CustomerDetailsResource> Get(int id)
        {
            var query = new FindByIdQuery<CustomerDetails>(id);
            var customerDetails = await _queryDispatcher.ExecuteAsync<CustomerDetails, FindByIdQuery<CustomerDetails>>(query);

            if (customerDetails == null)
            {
                throw new NotFoundException(id);
            }

            var resource = new CustomerDetailsResource
            {
                Id = customerDetails.Id,
                Email = customerDetails.Email,
                Name = customerDetails.Name,
                Href = HttpContext.GetHrefSelf()
            };

            return resource;
        }

        [HttpPost]
        public async Task<CustomerDetails> Post([FromBody] CustomerEditModel editModel)
        {
            var createCommand = new CreateCustomerCommand(editModel.Name, editModel.Email);
            var commandResult = await _commandsDispatcher.ExecuteAsync<CreateCustomerCommand, CommandResult<CustomerDetails>>(createCommand);

            if (commandResult.IsSuccess)
            {
                return commandResult.Result;
            }
            else
            {
                throw new CqrsApiApplicationException(commandResult.FailureReason);
            }
        }
    }
}