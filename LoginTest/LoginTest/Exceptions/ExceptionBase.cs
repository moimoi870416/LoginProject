namespace LoginTest.Exceptions
{
    public abstract class ExceptionBase : Exception
    {
        public abstract int ErrorCode { get; }

        public abstract override string Message { get; }
    }
}
