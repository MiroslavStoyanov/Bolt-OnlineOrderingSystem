namespace Bolt.Core.ExceptionHandling
{
    public class ErrorType
    {
        public ErrorType(int code, string message)
        {
            this.Code = code;
            this.Message = message;
        }

        public int Code { get; }

        public string Message { get; }
    }
}
