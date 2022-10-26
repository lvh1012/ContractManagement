namespace API.Model
{
    public class BaseResult<TModel>
    {
        public bool Success { get; set; } = true;
        public int Status { get; set; } = StatusCodes.Status200OK;
        public TModel Data { get; set; }
        public string? Message { get; set; }
        public string? ErrorInFile { get; set; }
        public string? ErrorMessage { get; set; }
        public Exception? Exception { get; set; }
        public Page? Page { get; set; }

        public BaseResult(bool success, int status, TModel data, string? message, string? errorInFile, string? errorMessage, Exception? exception, Page? page)
        {
            Success = success;
            Status = status;
            Data = data;
            Message = message;
            ErrorInFile = errorInFile;
            ErrorMessage = errorMessage;
            Exception = exception;
            Page = page;
        }

        public BaseResult(bool success, int status, TModel data)
        {
            Success = success;
            Status = status;
            Data = data;
        }

        public BaseResult(bool success, int status, string? message)
        {
            Success = success;
            Status = status;
            Message = message;
        }

        public static BaseResult<TModel> ReturnWithData(TModel data)
        {
            return new BaseResult<TModel>(true, StatusCodes.Status200OK, data);
        }

        public static BaseResult<TModel> ReturnWithError(string message)
        {
            return new BaseResult<TModel>(true, StatusCodes.Status200OK, message);
        }
    }
}
