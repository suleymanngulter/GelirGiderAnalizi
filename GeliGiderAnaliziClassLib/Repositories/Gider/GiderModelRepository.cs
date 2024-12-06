using GelirGiderAnalizi.Models;
using Microsoft.EntityFrameworkCore;

public class GiderModelRepository : IGiderModelRepository
{
    private readonly DbContext _context;
    private readonly DbSet<GiderModel> _dbSet;

    public GiderModelRepository(DbContext context)
    {
        _context = context;
        _dbSet = context.Set<GiderModel>();
    }

    public async Task<IEnumerable<GiderModel>> ListeleAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<GiderModel> ListeleByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task EkleAsync(GiderModel giderModel)
    {
        await _dbSet.AddAsync(giderModel);
        await _context.SaveChangesAsync();
    }

    public async Task EkleTopluAsync(IEnumerable<GiderModel> giderModels)
    {
        await _dbSet.AddRangeAsync(giderModels);
        await _context.SaveChangesAsync();
    }

    public async Task GuncelleAsync(GiderModel giderModel)
    {
        _dbSet.Update(giderModel);
        await _context.SaveChangesAsync();
    }

    public async Task GuncelleTopluAsync(IEnumerable<GiderModel> giderModels)
    {
        _dbSet.UpdateRange(giderModels);
        await _context.SaveChangesAsync();
    }

    public async Task SilAsync(GiderModel giderModel)
    {
        _dbSet.Remove(giderModel);
        await _context.SaveChangesAsync();
    }

    public async Task SilByIdAsync(int id)
    {
        var giderModel = await ListeleByIdAsync(id);
        if (giderModel != null)
        {
            _dbSet.Remove(giderModel);
            await _context.SaveChangesAsync();
        }
    }

    public async Task SilTopluAsync(IEnumerable<GiderModel> giderModels)
    {
        _dbSet.RemoveRange(giderModels);
        await _context.SaveChangesAsync();
    }
}
