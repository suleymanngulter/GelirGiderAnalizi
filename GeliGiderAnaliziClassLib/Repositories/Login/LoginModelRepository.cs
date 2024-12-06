using GelirGiderAnalizi.Models;
using Microsoft.EntityFrameworkCore;

public class LoginModelRepository:ILoginModelRepository
{
    private readonly DbContext _context;
    private readonly DbSet<LoginModel> _dbSet;

    public LoginModelRepository(DbContext context)
    {
        _context = context;
        _dbSet = context.Set<LoginModel>();
    }

    // Kullanıcı adı ve şifre doğrulaması
    public bool Dogrula(string kullaniciAdi, string sifre)
    {
        return _dbSet.Any(x => x.KullaniciAdi == kullaniciAdi && x.KullaniciSifre == sifre);
    }
}
