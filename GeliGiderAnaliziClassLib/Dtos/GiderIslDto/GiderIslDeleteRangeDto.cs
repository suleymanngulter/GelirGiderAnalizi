using MySql.EntityFrameworkCore.Extensions;
using Microsoft.EntityFrameworkCore;

namespace GelirGiderAnalizi.Dtos.GiderIslDto
{
    public class GiderIslDeleteRangeDto
    {
        public List<GiderIslDeleteDto>? GiderIslemList { get; set; }
    }
}
