using MySql.EntityFrameworkCore.Extensions;
using Microsoft.EntityFrameworkCore;

namespace GelirGiderAnalizi.Dtos.GiderDto
{
    public class GiderGetByIdDto
    {
        public int? Id { get; set; }  
        public string? Aciklama { get; set; }  
        public decimal? Tutar { get; set; }  
        public DateTime? Tarih { get; set; } = DateTime.MinValue;
    }
}
