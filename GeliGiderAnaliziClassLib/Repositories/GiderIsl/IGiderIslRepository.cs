using GelirGiderAnalizi.Models;

public interface IGiderIslModelRepository
{
    Task<IEnumerable<GiderIslModel>> ListeleAsync();
    Task<GiderIslModel> ListeleByIdAsync(int id);
    Task GuncelleAsync(GiderIslModel giderIslModel);
    Task SilByIdAsync(int id);
    Task SilAsync(GiderIslModel silModel);
    Task SilTopluAsync(GiderIslModel silModel);
}
