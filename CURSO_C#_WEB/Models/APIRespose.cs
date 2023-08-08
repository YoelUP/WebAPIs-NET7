using System.Net;

namespace CURSO_C__WEB.Models
{
    public class APIRespose
    {
        public HttpStatusCode statusCode { get; set; }

        public bool IsSuccessful { get; set; } = true;

        public List<string> ErrorMessages { get; set; }

        public object? Result { get; set; }
    }
}
