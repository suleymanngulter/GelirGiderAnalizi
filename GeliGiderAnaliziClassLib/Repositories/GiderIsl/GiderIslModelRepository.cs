using GelirGiderAnalizi.Models;
using Microsoft.EntityFrameworkCore;

public class GiderIslModelRepository : IGiderIslModelRepository
{
    private readonly DbContext _context;
    private readonly DbSet<GiderIslModel> _dbSet;

    public GiderIslModelRepository(DbContext context)
    {
        _context = context;
        _dbSet = context.Set<GiderIslModel>();
    }

    public async Task<IEnumerable<GiderIslModel>> ListeleAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<GiderIslModel> ListeleByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }
    public async Task EkleAsync(GiderIslModel giderIslModel)
    {
        _dbSet.AddAsync(giderIslModel);
        await _context.SaveChangesAsync();
    }
    public async Task EkleTopluAsync(GiderIslModel giderIslModel)
    {
        _dbSet.AddAsync(giderIslModel);
        await _context.SaveChangesAsync();
    }

    public async Task GuncelleAsync(GiderIslModel giderIslModel)
    {
        _dbSet.Update(giderIslModel);
        await _context.SaveChangesAsync();
    }
    public async Task SilAsync(GiderIslModel giderIslModel)
    {
        _dbSet.Remove(giderIslModel);
        await _context.SaveChangesAsync();
    }

    public async Task SilByIdAsync(int id)
    {
        var giderIslModel = await ListeleByIdAsync(id);
        if (giderIslModel != null)
        {
            _dbSet.Remove(giderIslModel);
            await _context.SaveChangesAsync();
        }
    }
    public async Task SilTopluAsync(GiderIslModel giderIslModel)
    {
        _dbSet.RemoveRange(giderIslModel);
        await _context.SaveChangesAsync();
    }

}
