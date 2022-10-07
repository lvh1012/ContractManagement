using Microsoft.AspNetCore.Mvc;

namespace API.Model
{
    public class BaseActionResult : IActionResult
    {
        private readonly BaseResult _result;

        public BaseActionResult(BaseResult result)
        {
            _result = result;
        }

        public async Task ExecuteResultAsync(ActionContext context)
        {
            var objectResult = new ObjectResult(_result.Exception ?? _result.Data)
            {
                StatusCode = _result.Exception != null
                    ? StatusCodes.Status500InternalServerError
                    : StatusCodes.Status200OK
            };

            await objectResult.ExecuteResultAsync(context);
        }
    }
}
