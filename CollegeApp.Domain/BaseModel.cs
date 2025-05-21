namespace CollegeApp.Domain;

public class ResponseHeader
{
    public string ResponseCode { get; set; }  // "0" for success, other codes for specific errors
    public string ResponseMessage { get; set; }
}

public class BaseResponseModel<T>
{
    public ResponseHeader ResponseHeader { get; set; }
    public T ResponseBody { get; set; }
}