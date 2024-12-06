using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using System.Threading.Tasks;
using GelirGiderAnalizi.Services;
using GelirGiderAnalizi.Dtos.GiderIslDto;

namespace GelirGiderAnalizi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GiderIslController : Controller
    {
        private readonly IGiderIslService _giderIslService;

        public GiderIslController(IGiderIslService giderIslService)
        {
            _giderIslService = giderIslService;
        }

        
        //POST /api/GiderIsl/GelirGiderIslemYap
        [HttpPost("GelirGiderIslemYap")]
        public async Task<IActionResult> GelirGiderIslemYap([FromBody] GelirGiderIslemYapDto dto)
        {
            string jwtToken="";
            if (Request.Headers.TryGetValue("Authorization", out var token))
            {
                jwtToken = token.ToString().Replace("Bearer ", "");
            }
            else
            {
                return BadRequest("Token bulunamadı.");
            }
            
            if (dto == null)
            {
                return BadRequest(new { message = "Geçersiz veri gönderildi." });
            }

            try
            {
                if (dto.Tutar <= 0)
                {
                    return BadRequest(new { message = "Tutar sıfırdan büyük olmalıdır." });
                }

                await _giderIslService.GelirGiderIslemYapAsync(dto,jwtToken);

                return Ok(new { message = "Gelir/Gider işlemi başarıyla gerçekleştirildi." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Bir hata oluştu.", error = ex.Message });
            }
        }


        // POST /api/GiderIsl/getall
        [HttpPost("getall")]
        public async Task<IActionResult> GetAll([FromBody] GiderIslGetAllDto dto)
        {
            string jwtToken = "";
            if (Request.Headers.TryGetValue("Authorization", out var token))
            {
                jwtToken = token.ToString().Replace("Bearer ", "");
            }
            else
            {
                return BadRequest("Token bulunamadı.");
            }
            try
            {
                var result = await _giderIslService.GetAllGiderIslAsync(dto,jwtToken);
                if (result == null || !result.Any())
                {
                    return NotFound(new { message = "Hiçbir kayıt bulunamadı." });
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Bir hata oluştu.", error = ex.Message });
            }
        }

        // GET /api/GiderIsl/getbyid
        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            string jwtToken = "";
            if (Request.Headers.TryGetValue("Authorization", out var token))
            {
                jwtToken = token.ToString().Replace("Bearer ", "");
            }
            else
            {
                return BadRequest("Token bulunamadı.");
            }
            try
            {
                var result = await _giderIslService.GetByIdAsync(id,jwtToken);
                if (result == null)
                {
                    return NotFound(new { message = $"ID {id} ile gider işlemi bulunamadı." });
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Bir hata oluştu.", error = ex.Message });
            }
        }

        // POST /api/GiderIsl/add
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] GiderIslAddDto dto)
        {
            string jwtToken = "";
            if (Request.Headers.TryGetValue("Authorization", out var token))
            {
                jwtToken = token.ToString().Replace("Bearer ", "");
            }
            else
            {
                return BadRequest("Token bulunamadı.");
            }
            try
            {
                if (dto == null)
                {
                    return BadRequest(new { message = "Geçersiz gider işlem verisi." });
                }

                await _giderIslService.AddAsync(dto,jwtToken);

                return Ok(new { message = "Gider işlemi başarıyla eklendi." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Bir hata oluştu.", error = ex.Message });
            }
        }

        // POST /api/GiderIsl/addrange
        [HttpPost("addrange")]
        public async Task<IActionResult> AddRange([FromBody] GiderIslAddRangeDto dto)
        {
            string jwtToken = "";
            if (Request.Headers.TryGetValue("Authorization", out var token))
            {
                jwtToken = token.ToString().Replace("Bearer ", "");
            }
            else
            {
                return BadRequest("Token bulunamadı.");
            }
            try
            {
                if (dto == null || !dto.GiderIslListesi.Any())
                {
                    return BadRequest(new { message = "Eklemek için gider işlem listesi boş olamaz." });
                }

                await _giderIslService.AddRangeAsync(dto,jwtToken);

                return Ok(new { message = "Gider işlemleri başarıyla eklendi." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Bir hata oluştu.", error = ex.Message });
            }
        }

        // PUT /api/GiderIsl/update
        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] GiderIslUpdateDto dto)
        {
            string jwtToken = "";
            if (Request.Headers.TryGetValue("Authorization", out var token))
            {
                jwtToken = token.ToString().Replace("Bearer ", "");
            }
            else
            {
                return BadRequest("Token bulunamadı.");
            }
            try
            {
                if (dto == null)
                {
                    return BadRequest(new { message = "Geçersiz gider işlem verisi." });
                }

                await _giderIslService.UpdateAsync(dto,jwtToken);

                return Ok(new { message = "Gider işlemi başarıyla güncellendi." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Bir hata oluştu.", error = ex.Message });
            }
        }

        // PUT /api/GiderIsl/updaterange
        [HttpPut("updaterange")]
        public async Task<IActionResult> UpdateRange([FromBody] GiderIslUpdateRangeDto dto)
        {
            string jwtToken = "";
            if (Request.Headers.TryGetValue("Authorization", out var token))
            {
                jwtToken = token.ToString().Replace("Bearer ", "");
            }
            else
            {
                return BadRequest("Token bulunamadı.");
            }
            try
            {
                if (dto == null || !dto.GiderIslemUpdates.Any())
                {
                    return BadRequest(new { message = "Güncellenecek gider işlemleri bulunamadı." });
                }

                await _giderIslService.UpdateRangeAsync(dto,jwtToken);

                return Ok(new { message = "Gider işlemleri başarıyla güncellendi." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Bir hata oluştu.", error = ex.Message });
            }
        }

        // DELETE /api/GiderIsl/deletebyid
        [HttpDelete("deletebyid")]
        public async Task<IActionResult> DeleteById([FromQuery] int id)
        {
            string jwtToken = "";
            if (Request.Headers.TryGetValue("Authorization", out var token))
            {
                jwtToken = token.ToString().Replace("Bearer ", "");
            }
            else
            {
                return BadRequest("Token bulunamadı.");
            }
            try
            {
                await _giderIslService.DeleteByIdAsync(id,jwtToken);
                return Ok(new { message = $"ID {id} ile gider işlemi başarıyla silindi." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Bir hata oluştu.", error = ex.Message });
            }
        }

        // POST /api/GiderIsl/deleterange
        [HttpPost("deleterange")]
        public async Task<IActionResult> DeleteRange([FromBody] GiderIslDeleteRangeDto dto)
        {
            string jwtToken = "";
            if (Request.Headers.TryGetValue("Authorization", out var token))
            {
                jwtToken = token.ToString().Replace("Bearer ", "");
            }
            else
            {
                return BadRequest("Token bulunamadı.");
            }
            try
            {
                if (dto == null || !dto.GiderIslemList.Any())
                {
                    return BadRequest(new { message = "Silinecek gider işlemleri bulunamadı." });
                }

                await _giderIslService.DeleteRangeAsync(dto, jwtToken);

                return Ok(new { message = "Birden fazla gider işlemi silindi." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Bir hata oluştu.", error = ex.Message });
            }
        }
    }
}
