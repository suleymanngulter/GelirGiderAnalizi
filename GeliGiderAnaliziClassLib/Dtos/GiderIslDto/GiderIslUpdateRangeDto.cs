using MySql.EntityFrameworkCore.Extensions;
using Microsoft.EntityFrameworkCore;

namespace GelirGiderAnalizi.Dtos.GiderIslDto
{
    public class GiderIslUpdateRangeDto
    {
        public List<GiderIslUpdateDto>? GiderIslemUpdates { get; set; }
    }
}
