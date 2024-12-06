using GelirGiderAnalizi.Dtos.GiderDto;
using GelirGiderAnalizi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GelirGiderAnalizi.Services.GiderService
{
    public interface IGiderService
    {
        Task<List<GiderGetAllDto>> GetAllGiderlerAsync(GiderGetAllDto filtre, string token);

        Task<GiderControlDeleteDto> ControlDeleteAsync(GiderModel gider,string token);

        Task<GiderControlDeleteByIdDto> ControlDeleteByIdAsync(int id, string token);

        Task<GiderGetByIdDto> GetByIdAsync(int id, string token);

        Task AddAsync(GiderAddDto giderDto, string token);

        Task AddRangeAsync(GiderAddRangeDto giderlerDto, string token);

        Task UpdateAsync(GiderUpdateDto giderDto, string token);

        Task UpdateRangeAsync(GiderUpdateRangeDto giderlerDto, string token);

        Task DeleteAsync(GiderDeleteDto giderDto, string token);

        Task DeleteByIdAsync(int id, string token);

        Task DeleteRangeAsync( List<GiderDeleteDto> giderler, string token);
    }
}
