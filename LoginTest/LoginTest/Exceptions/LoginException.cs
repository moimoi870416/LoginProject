namespace LoginTest.Exceptions
{
    public class LoginException : ExceptionBase
    {
        public override int ErrorCode => StatusCodes.Status401Unauthorized;

        public override string Message => "Invalid account or password";
    }
}
