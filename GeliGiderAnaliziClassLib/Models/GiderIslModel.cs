using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore.Extensions;

namespace GelirGiderAnalizi.Models
{
    public class GiderIslModel
    {
        public int? Id { get; set; }   // Varsayılan değer atanır
        public int? GiderId { get; set; }  
        public int? KasaId { get; set; }  
        public string? EvrakNo { get; set; }   // String için boş değer atanır
        public string? Aciklama { get; set; }  
        public string? OdemeDurumu { get; set; }  
        public string? OdemeSekli { get; set; }  
        public string? SubeAdi { get; set; }  
        public decimal? Tutar { get; set; } = 0m; // Decimal için varsayılan değer
        public DateTime? Tarih { get; set; } = DateTime.MinValue; // Varsayılan tarih
        public string? Turu { get; set; }  
    }

}



