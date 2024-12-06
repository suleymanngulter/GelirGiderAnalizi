using MySql.EntityFrameworkCore.Extensions;
using Microsoft.EntityFrameworkCore;

namespace GelirGiderAnalizi.Dtos.GiderIslDto
{
    public class GiderIslAddDto
    {
        public string? Aciklama { get; set; }  
        public int? BankaIslId { get; set; } 
        public string? EvrakNo { get; set; }  
        public int? GiderId { get; set; }  
        public int? Id { get; set; }  
        public int? KasaId { get; set; }  
        public string? KullaniciAdi { get; set; }  
        public string? OdemeDurumu { get; set; }  
        public string? OdemeSekli { get; set; }  
        public string? SubeAdi { get; set; }  
        public DateTime? Tarih { get; set; }=DateTime.MinValue;
        public string? Tip { get; set; }  
        public double? Tutar { get; set; }  
    }

}
