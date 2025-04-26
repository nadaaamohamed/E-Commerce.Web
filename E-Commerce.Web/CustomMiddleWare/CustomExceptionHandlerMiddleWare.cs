using DomainLayer.Expections;
using Shared.ErrorModels;
using System.Net;
using System.Text.Json;

namespace E_Commerce.Web.CustomMiddleWare
{
    public class CustomExceptionHandlerMiddleWare
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<CustomExceptionHandlerMiddleWare> _logger;
        public CustomExceptionHandlerMiddleWare(RequestDelegate Next , ILogger<CustomExceptionHandlerMiddleWare>
            logger)
        {
            _next = Next;
            _logger = logger;
        }

        public async Task InvokeAsync (HttpContext httpContext)
        {
            try
            {
               await _next.Invoke(httpContext);

            }
            catch(Exception ex)
            {
                _logger.LogError(ex , "An error occurred while processing the request.");
                //httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                httpContext.Response.StatusCode = ex switch
                {
                    ProductNotFoundException => StatusCodes.Status404NotFound,
                    _ => StatusCodes.Status500InternalServerError
                };
                httpContext.Response.ContentType = "application/json";
                var ErrorResponse = new ErrorToReturn()
                {
                    ErrorMessage = ex.Message,
                    StatusCode = httpContext.Response.StatusCode
                };
                //var ResponseToReturn= JsonSerializer.Serialize(ErrorResponse);

                //await httpContext.Response.WriteAsync(ResponseToReturn);
              await  httpContext.Response.WriteAsJsonAsync(ErrorResponse);


            }
        }
        
    }
}
