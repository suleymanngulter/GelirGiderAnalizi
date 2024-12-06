using GelirGiderAnalizi.Dtos.GiderIslDto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GelirGiderAnalizi.Services
{
    public interface IGiderIslService
    {
        Task<List<GelirGiderIslemYapDto>> GetAllGiderIslAsync(GiderIslGetAllDto dto,string token);
        Task<GiderIslGetByIdDto> GetByIdAsync(int id, string token);
        Task AddAsync(GiderIslAddDto dto, string token);
        Task AddRangeAsync(GiderIslAddRangeDto dto, string token);
        Task UpdateAsync(GiderIslUpdateDto dto, string token);
        Task UpdateRangeAsync(GiderIslUpdateRangeDto dto, string token);
        Task DeleteByIdAsync(int id, string token);
        Task DeleteRangeAsync(GiderIslDeleteRangeDto dto, string token);
        Task GelirGiderIslemYapAsync(GelirGiderIslemYapDto dto,string token);
        Task GiderIslDeleteAsync(GiderIslDeleteDto dto, string token);
    }
}
