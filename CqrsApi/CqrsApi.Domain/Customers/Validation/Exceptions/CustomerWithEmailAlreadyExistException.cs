using System;
using System.Runtime.Serialization;

namespace CqrsApi.Domain.Customers.Validation.Exceptions
{
    [Serializable]
    public class CustomerWithEmailAlreadyExistException : Exception
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