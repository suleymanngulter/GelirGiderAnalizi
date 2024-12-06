using MySql.EntityFrameworkCore.Extensions;
using Microsoft.EntityFrameworkCore;

namespace GelirGiderAnalizi.Dtos.GiderDto
{
    public class GiderDeleteRangeDto
    {
        public List<GiderDeleteDto>? Giderler { get; set; }
    }
}
