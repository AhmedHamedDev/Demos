namespace ExceptionHandler.Exceptions.Contract
{
    public interface IExceptionHandleBase
    {
        public Task Handle(Exception exp);
    }
}
