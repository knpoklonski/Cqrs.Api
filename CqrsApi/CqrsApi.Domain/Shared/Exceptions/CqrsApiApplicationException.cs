using System;
using System.Runtime.Serialization;

namespace CqrsApi.Domain.Shared.Exceptions
{
    [Serializable]
    public class CqrsApiApplicationException : Exception
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public CqrsApiApplicationException()
        {
        }

        public CqrsApiApplicationException(string message) : base(message)
        {
        }

        public CqrsApiApplicationException(string message, Exception inner) : base(message, inner)
        {
        }

        protected CqrsApiApplicationException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}