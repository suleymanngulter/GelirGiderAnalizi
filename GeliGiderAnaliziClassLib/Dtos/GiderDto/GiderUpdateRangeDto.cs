using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore.Extensions;

namespace GelirGiderAnalizi.Dtos.GiderDto
{
    public class GiderUpdateRangeDto
    {
        public List<GiderUpdateDto>? Giderler { get; set; }
    }

}
