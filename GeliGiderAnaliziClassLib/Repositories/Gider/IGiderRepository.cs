using GelirGiderAnalizi.Models;

public interface IGiderModelRepository
{
    Task<IEnumerable<GiderModel>> ListeleAsync();
    Task<GiderModel> ListeleByIdAsync(int id);
    Task EkleAsync(GiderModel giderModel);
    Task EkleTopluAsync(IEnumerable<GiderModel> giderModels);
    Task GuncelleAsync(GiderModel giderModel);
    Task GuncelleTopluAsync(IEnumerable<GiderModel> giderModels);
    Task SilAsync(GiderModel giderModel);
    Task SilByIdAsync(int id);
    Task SilTopluAsync(IEnumerable<GiderModel> giderModels);
}
