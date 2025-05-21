namespace CollegeApp.Domain.Helpers
{
    public static class ResponseFactory
    {
        public static BaseResponseModel<T> Success<T>(T data, string message = "Success")
        {
            return new BaseResponseModel<T>
            {
                ResponseHeader = new ResponseHeader
                {
                    ResponseCode = "0",
                    ResponseMessage = message
                },
                ResponseBody = data
            };
        }

        public static BaseResponseModel<IEnumerable<T>> SuccessList<T>(List<T> data, string message = "Success")
        {
            return new BaseResponseModel<IEnumerable<T>>
            {
                ResponseHeader = new ResponseHeader
                {
                    ResponseCode = "0",
                    ResponseMessage = message
                },
                ResponseBody = data
            };
        }

        public static BaseResponseModel<T> SqlError<T>(string message)
        {
            return new BaseResponseModel<T>
            {
                ResponseHeader = new ResponseHeader
                {
                    ResponseCode = "500",
                    ResponseMessage = $"SQL Error: {message}"
                },
                ResponseBody = default
            };
        }

        public static BaseResponseModel<T> Error<T>(string message)
        {
            return new BaseResponseModel<T>
            {
                ResponseHeader = new ResponseHeader
                {
                    ResponseCode = "501",
                    ResponseMessage = $"General Error: {message}"
                },
                ResponseBody = default
            };
        }
    }
}