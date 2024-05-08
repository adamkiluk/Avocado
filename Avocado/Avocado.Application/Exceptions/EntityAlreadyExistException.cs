namespace Avocado.Application.Exceptions
{
    using System;

    public class EntityAlreadyExistException : Exception
    {
        public EntityAlreadyExistException() : base()
        {
        }

        public EntityAlreadyExistException(string message) : base(message)
        {
        }
    }
}
