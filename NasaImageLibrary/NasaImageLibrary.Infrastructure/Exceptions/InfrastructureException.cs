using System;

namespace NasaImageLibrary.Infrastructure.Exceptions
{
    public class InfrastructureException : Exception
    {
        public InfrastructureException()
        {

        }

        public InfrastructureException(string errorMessage) : base(errorMessage)
        {

        }

        public InfrastructureException(string errorMessage, System.Exception innerException) : base(errorMessage, innerException)
        {

        }
    }
}
