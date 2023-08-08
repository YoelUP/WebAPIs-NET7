using CURSO_C__WEB.Models.DTO;

namespace CURSO_C__WEB.Services.IServices
{
    public interface IProvinciaService
    {
        Task<T> ObteinAllP<T>();

        Task<T> ObteinP<T>(int id);

        Task<T> CreateP<T>(ProvinciaDTO entity);

        Task<T> UpdateP<T>(ProvinciaDTO entity, int id);

        Task<T> RemoveP<T>(int id);
    }
}
