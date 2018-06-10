using System.Threading.Tasks;
using CqrsApi.Domain.Customers.Commands;
using CqrsApi.Domain.Customers.Queries;
using CqrsApi.Domain.Customers.Validation;
using CqrsApi.Domain.Customers.Validation.Exceptions;
using CqrsApi.Domain.Infrastructure.Queries;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CqrsApi.Domain.Tests
{
    [TestClass]
    public class CreateCustomerValidationHandlerTests
    {
        private Mock<IQueriesDispatcher> _queryDispatcherMock;
        private CreateCustomerValidationHandler _validator;

        [TestInitialize]
        public void SetUp()
        {
            _queryDispatcherMock = new Mock<IQueriesDispatcher>();
            _validator = new CreateCustomerValidationHandler(_queryDispatcherMock.Object);
        }

        [TestMethod]
        public async Task Validate_ShouldThrowException_If_Email_AlreadyExist()
        {
            _queryDispatcherMock.Setup(x => x.ExecuteAsync<bool, CheckExistingCustomerByEmailQuery>(It.IsAny<CheckExistingCustomerByEmailQuery>()))
                .ReturnsAsync(true);

            var command = new CreateCustomerCommand("name", "test@mail.com");
            await Assert.ThrowsExceptionAsync<CustomerWithEmailAlreadyExistException>(() => _validator.Validate(command));
        }

        [TestMethod]
        public async Task Validate_ShouldNotThrowException_If_Email_DoesnNotExist()
        {
            _queryDispatcherMock.Setup(x => x.ExecuteAsync<bool, CheckExistingCustomerByEmailQuery>(It.IsAny<CheckExistingCustomerByEmailQuery>()))
                .ReturnsAsync(false);

            var command = new CreateCustomerCommand("name", "test@mail.com");
            try
            {
                await _validator.Validate(command);
            }
            catch
            {
                Assert.Fail("Validation throw exception");
            }
        }
    }
}
