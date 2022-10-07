namespace API.Model
{
    public class BaseResult
    {
        public bool Success { get; set; } = true;
        public int Status { get; set; } = StatusCodes.Status200OK;
        public object Data { get; set; }
        public string? Message { get; set; }
        public string? ErrorInFile { get; set; }
        public string? ErrorMessage { get; set; }
        public Exception? Exception { get; set; }

        public BaseResult(bool success, int status, object data, string? message, string? errorInFile, string? errorMessage, Exception? exception)
        {
            Success = success;
            Status = status;
            Data = data;
            Message = message;
            ErrorInFile = errorInFile;
            ErrorMessage = errorMessage;
            Exception = exception;
        }
    }
}
