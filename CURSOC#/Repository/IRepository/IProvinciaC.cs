using CURSOC_.Models;

namespace CURSOC_.Repository.IRepository
{
    public interface IProvinciaC: IRepository<ProvinciaC>
    {
        Task<ProvinciaC> UpdateP(ProvinciaC entity);
    }
}
