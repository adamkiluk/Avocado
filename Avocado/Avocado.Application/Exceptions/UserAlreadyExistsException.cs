namespace Avocado.Application.Exceptions
{
    using System;

    public class UserAlreadyExistsException : Exception
    {
        public UserAlreadyExistsException() : base()
        {
        }

        public UserAlreadyExistsException(string message) : base(message)
        {
        }
    }
}
