namespace LoginTest.Exceptions
{
    public class JwtException : ExceptionBase
    {
        public override int ErrorCode => StatusCodes.Status401Unauthorized;

        public override string Message => "invalid credential";
    }
}
