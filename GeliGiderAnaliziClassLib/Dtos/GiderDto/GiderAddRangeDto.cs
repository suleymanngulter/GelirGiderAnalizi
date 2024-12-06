using MySql.EntityFrameworkCore.Extensions;
using Microsoft.EntityFrameworkCore;

namespace GelirGiderAnalizi.Dtos.GiderDto
{
    public class GiderAddRangeDto
    {
        public List<GiderAddDto>? Giderler { get; set; }
    }

}
