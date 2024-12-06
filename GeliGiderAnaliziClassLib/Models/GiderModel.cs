using MySql.EntityFrameworkCore.Extensions;
using Microsoft.EntityFrameworkCore;

namespace GelirGiderAnalizi.Models
{
    public class GiderModel
    {
        public int? Id { get; set; }  
        public string? AboneNo { get; set; }=string.Empty;
        public string? GiderAciklama { get; set; }=string.Empty;
        public string? GiderAdi { get; set; } =string.Empty;
        public string? GiderKategori { get; set; }  
        public string? GiderKodu { get; set; }=string.Empty ;
        public string? GiderTuru { get; set; } 
        public string? KullaniciAdi { get; set; }  
        public string? SubeAdi { get; set; }=string.Empty;
    }
}
