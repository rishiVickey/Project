namespace API.Errors
{
    public class ApiResponse
    {
        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatuscode( statusCode);
        }

        public int StatusCode { get; set; }

        public string Message { get; set; }
  
       public string GetDefaultMessageForStatuscode(int statusCode){
           return statusCode switch {
               400 => "A bad request, you have made",
               401 => "Authorized, you are not",
               404 => "Resource found, it was not",
               500 => "Error are the path to the dark side , Error leads to anger , Anger leads to hate, hate leads to career change",
               _ => null
           };
       }

    }
}