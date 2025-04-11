namespace PolizasService.Models
{
    public class Result
    {
        public bool Success { get; set; }
        public string Message  { get; set; }
        public int StatusCode { get; set; }
        public object Data { get; set; }

        public static Result SuccessResult(string message = "Operación exitosa", object data = null)
        {
            return new Result
            {
                Success = true,
                Message = message,
                StatusCode = 200,
                Data = data
            };
        }

        public static Result FailureResult(string message, int statusCode = 400)
        {
            return new Result
            {
                Success = false,
                Message = message,
                StatusCode = statusCode,
                Data = null
            };
        }
    }
}
