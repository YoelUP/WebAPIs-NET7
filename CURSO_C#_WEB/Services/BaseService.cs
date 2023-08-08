using CURSO_C__WEB.Models;
using CURSO_C__WEB.Services.IServices;
using CURSOC__UTILITY;
using Newtonsoft.Json;
using System.Text;

namespace CURSO_C__WEB.Services
{
    public class BaseService : IBaseService
    {
        public APIRespose aResponse { get; set; }

        public IHttpClientFactory _httpCliente { get; set; }
        public BaseService(IHttpClientFactory httpCliente)
        {
            this.aResponse = new APIRespose();
            _httpCliente = httpCliente;
        }

        public async Task<T> SendAsync<T>(APIRequest apiRequest)
        {
            try
            {
                var client = _httpCliente.CreateClient("CursoC3");
                HttpRequestMessage message = new HttpRequestMessage();
                message.Headers.Add("Accept", "application/json");
                message.RequestUri = new Uri(apiRequest.Url);

                if (apiRequest.Data != null)
                {
                    message.Content = new StringContent(JsonConvert.SerializeObject(apiRequest.Data),
                        Encoding.UTF8, "application/json");
                }
                switch (apiRequest.APITipo)
                {
                    case DS.APITipo.POST:
                        message.Method = HttpMethod.Post;
                        break;
                    case DS.APITipo.PUT:
                        message.Method = HttpMethod.Put;
                        break;
                    case DS.APITipo.DELETE:
                        message.Method = HttpMethod.Delete;
                        break;
                    default:
                        message.Method = HttpMethod.Get;
                        break;
                }

                HttpResponseMessage apiReponse = null;
                apiReponse = await client.SendAsync(message);
                var apiContent = await apiReponse.Content.ReadAsStringAsync();
                var APIResponse = JsonConvert.DeserializeObject<T>(apiContent);
                return APIResponse;
            }
            catch (Exception ex)
            {
                var dto = new APIRespose
                {
                    ErrorMessages = new List<string> { Convert.ToString(ex.Message) },
                    IsSuccessful = false,
                };
                var res = JsonConvert.SerializeObject(dto);
                var APIResponse = JsonConvert.DeserializeObject<T>(res);
                return APIResponse;
            }
        }
    }
}
