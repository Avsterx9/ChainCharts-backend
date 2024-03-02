namespace Common.Exceptions;
public class NotFoundException : Exception
{
    public NotFoundException(string ErrorCode) : base(ErrorCode)
    {
    
    }
}
