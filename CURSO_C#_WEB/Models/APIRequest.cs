using static CURSOC__UTILITY.DS;

namespace CURSO_C__WEB.Models
{
    public class APIRequest
    {
        public APITipo APITipo { get; set; } = APITipo.GET;

        public string Url { get; set; }

        public object Data { get; set; }
    }
}
