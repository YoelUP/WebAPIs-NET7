using CURSO_C__WEB.Models;
using CURSO_C__WEB.Models.DTO;
using CURSO_C__WEB.Services.IServices;
using CURSOC__UTILITY;

namespace CURSO_C__WEB.Services
{
    public class ProvinciaService : BaseService, IProvinciaService
    {

        public readonly IHttpClientFactory _httpClientFactory;
        public string _provinciaURL { get; set; }
        public ProvinciaService(IHttpClientFactory httpClientFactory, IConfiguration configuration) : base(httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _provinciaURL = configuration.GetValue<string>("ConnectionStrings:API_URL");
        }

        public Task<T> CreateP<T>(ProvinciaDTO entity)
        {
            return SendAsync<T>(new APIRequest()
            {
                APITipo = DS.APITipo.POST,
                Data = entity,
                Url = _provinciaURL + "/api/Provincia"
            });
        }

        public Task<T> ObteinAllP<T>()
        {
            return SendAsync<T>(new APIRequest()
            {
                APITipo = DS.APITipo.GET,
                Url = _provinciaURL + "/api/Provincia/"
            });
        }

        public Task<T> ObteinP<T>(int id)
        {
            return SendAsync<T>(new APIRequest()
            {
                APITipo = DS.APITipo.GET,
                Url = _provinciaURL + "/api/Provincia/" + id
            });
        }

        public Task<T> RemoveP<T>(int id)
        {
            return SendAsync<T>(new APIRequest()
            {
                APITipo = DS.APITipo.DELETE,
                Url = _provinciaURL + "/api/Provincia/" + id
            });
        }

        public Task<T> UpdateP<T>(ProvinciaDTO entity, int id)
        {
            return SendAsync<T>(new APIRequest()
            {
                APITipo = DS.APITipo.PUT,
                Data = entity,
                Url = _provinciaURL + "/api/Provincia/" + id
            });
        }
    }
}
