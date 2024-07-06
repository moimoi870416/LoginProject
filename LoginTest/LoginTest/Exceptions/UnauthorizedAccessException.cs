namespace LoginTest.Exceptions
{
    public class UnauthorizedAccessException : ExceptionBase
    {
        public override int ErrorCode => StatusCodes.Status403Forbidden;

        public override string Message => "Access Denied";
    }
}
