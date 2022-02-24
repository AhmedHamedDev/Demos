using ExceptionHandler.Exceptions.Contract;
using ExceptionHandler.Exceptions.Types;

namespace ExceptionHandler.Exceptions.Handlers
{
    public class HandleTestException : IExceptionManager<TestException>
    {
        public Task Handle(Exception exp)
        {
            return Task.CompletedTask;
        }
    }
}
