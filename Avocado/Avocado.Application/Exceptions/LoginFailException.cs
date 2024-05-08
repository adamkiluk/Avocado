namespace Avocado.Application.Exceptions
{
    using System;

    public class LoginFailException : Exception
    {
        public LoginFailException() : base()
        {
        }

        public LoginFailException(string message) : base(message)
        {
        }

        public LoginFailException(string name, object key)
            : base($"Entity \"{name}\" ({key}) was not found.")
        {
        }
    }
}
