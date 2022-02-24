using ExceptionHandler.Exceptions.Contract;
using ExceptionHandler.Exceptions.Types;

namespace ExceptionHandler.Exceptions.Handlers
{
    public class HandleNewException : IExceptionManager<NewException>
    {
        public Task Handle(Exception exp)
        {
            throw new TestException();
            return Task.CompletedTask;
        }
    }
}
