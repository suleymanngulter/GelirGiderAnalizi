using MySql.EntityFrameworkCore.Extensions;
using Microsoft.EntityFrameworkCore;

namespace GelirGiderAnalizi.Dtos.GiderIslDto
{
    public class GiderIslAddRangeDto
    {
        public List<GiderIslAddDto>? GiderIslListesi { get; set; }
    }
}
