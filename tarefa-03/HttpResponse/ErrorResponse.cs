using Microsoft.AspNetCore.Http;

namespace tarefa_03.HttpResponse
{
    public class ErrorResponse
    {
        public ErrorResponse() { }
        public ErrorResponse(string error, int statusCode = StatusCodes.Status400BadRequest)
        {
            Error = error;
            StatusCode = statusCode;
        }

        public int StatusCode { get; set; }
        public string Error { get; set; }
    }
}
