using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore.Extensions;

namespace GelirGiderAnalizi.Dtos.GiderDto
{

    public class GiderGetAllDto
    {
        public string? AranacakKelime { get; set; }  
        public List<string>? AranacakKelimeIncludes { get; set; }
        public int? AranacakKelimeInt { get; set; }  
        public List<string>? AranacakKelimeSutuns { get; set; }
        public DateTime? BaslangicTarih { get; set; }
        public DateTime? BitisTarih { get; set; }
        public bool Desc { get; set; }
        public List<string>? Includes { get; set; }
        public List<string>? NullFiltrelemeYapilacaklar { get; set; }
        public string? OrderBy { get; set; }
        public List<string>? SearchType { get; set; }
        public string? SubeAdi { get; set; }  
        public string? TarihSutunAdi { get; set; }  
    }
}
