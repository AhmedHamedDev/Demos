namespace ExceptionHandler.Exceptions.Contract
{
    public interface IExceptionManager<T>
    {
        public Task Handle(Exception exp);
    }
}
