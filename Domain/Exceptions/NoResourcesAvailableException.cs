using System;

namespace Domain.Exceptions
{
    public class NoResourcesAvailableException : Exception
    {
        public NoResourcesAvailableException(string message)
            : base(message)
        {

        }
    }
}
