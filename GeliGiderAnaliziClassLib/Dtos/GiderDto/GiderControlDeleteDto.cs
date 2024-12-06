using MySql.EntityFrameworkCore.Extensions;
using Microsoft.EntityFrameworkCore;

namespace GelirGiderAnalizi.Dtos.GiderDto
{
    public class GiderControlDeleteDto
    {
        public string? AboneNo { get; set; }  
        public string? GiderAciklama { get; set; }  
        public string? GiderAdi { get; set; }  
        public string? GiderKategori { get; set; }  
        public string? GiderKodu { get; set; }  
        public string? GiderTuru { get; set; }  
        public int Id { get; set; }  
        public string? KullaniciAdi { get; set; }  
        public string? SubeAdi { get; set; }  
    }
}
