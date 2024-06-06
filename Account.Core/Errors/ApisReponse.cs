using System.Text.Json.Serialization;

namespace Account.Apis.Errors
{
    public class ApiResponse
    {
        [JsonIgnore]
        public int StatusCode { get; set; }
        [JsonIgnore]
        public string Message { get; set; }
        public object Data { get; set; }
        public ApiResponse()
        {
        }
        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(StatusCode);
        }
        //create ctor takes three parameters
        public ApiResponse(int statusCode, string message, object data)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(StatusCode);
            Data = data;
        }
        // Provides default messages for common HTTP status codes
        private string? GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "Bad Request",
                401 => "You are not Authorized",
                404 => "Resource Not Found",
                500 => "Internal Server Error",
                _ => null,
            };
        }
    }

}
