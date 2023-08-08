using CURSO_C__WEB.Models;

namespace CURSO_C__WEB.Services.IServices
{
    public interface IBaseService
    {
        public APIRespose aResponse { get; set; }

        Task<T> SendAsync<T>(APIRequest apiRequest);
    }
}
