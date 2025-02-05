using System.Runtime.Serialization;

throw new Exception();

Console.ReadKey();

// [Serializable]
public class CustomException : Exception
{
    public int StatusCode { get; }

    // These are additionals. Microsoft recommends only the 'Exception' ending and three constructors. But it's useful to know these things exist.
    //protected CustomException(SerializationInfo info, StreamingContext context) : base(info, context)
    //{

    //}

    public CustomException()
    {
        
    }

    public CustomException(string message, int statusCode) : base(message)
    {
        StatusCode = statusCode;
    }
    
    public CustomException(string message, int statusCode, Exception innerException) : base(message)
    {
        StatusCode = statusCode;
    }

    public CustomException(string message) : base(message)
    {
        
    }

    public CustomException(string message, Exception innerException) : base(message, innerException)
    {
        
    }
}