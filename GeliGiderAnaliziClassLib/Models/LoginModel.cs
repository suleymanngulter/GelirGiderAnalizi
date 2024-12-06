using MySql.EntityFrameworkCore.Extensions;
using Microsoft.EntityFrameworkCore;

namespace GelirGiderAnalizi.Models
{
    public class LoginModel
    {
        public string? VergiNumarasi { get; set; }  
        public string? KullaniciAdi { get; set; }  
        public string? KullaniciSifre { get; set; }  
        public string? VeritabaniAd { get; set; }  
        public string? DonemYil { get; set; }  
        public string? SubeAd { get; set; }  
        public string? ApiKullaniciAdi { get; set; }  
        public string? ApiKullaniciSifre { get; set; }  
    }
}
