using System;
using System.Runtime.Serialization;
using CqrsApi.Domain.Shared.Exceptions;

namespace CqrsApi.Domain.Customers.Validation.Exceptions
{
    [Serializable]
    public class CustomerWithEmailAlreadyExistException : CqrsApiApplicationException
    {
        public CustomerWithEmailAlreadyExistException()
        {
        }

        public CustomerWithEmailAlreadyExistException(string email) : base($"Customer with {email} already exist")
        {
        }

        protected CustomerWithEmailAlreadyExistException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}