using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using GelirGiderAnalizi.Models;
using GelirGiderAnalizi.Dtos.GiderDto;
using GelirGiderAnalizi.Services.GiderService;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace GelirGiderAnalizi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GiderController : Controller
    {
        private readonly IGiderService _giderService;

        public GiderController(IGiderService giderService)
        {
            _giderService = giderService;
        }



        // POST /api/Gider/getall
        [HttpPost("getall")]
        public async Task<IActionResult> GetAll([FromBody] GiderGetAllDto filtre)
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
                var result = await _giderService.GetAllGiderlerAsync(filtre,jwtToken);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Bir hata oluştu.", error = ex.Message });
            }

        }

        // POST /api/Gider/ControlDelete
        [HttpPost("ControlDelete")]
        public async Task<IActionResult> ControlDelete([FromBody] GiderModel gider)
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
                var controlResult = await _giderService.ControlDeleteAsync(gider,jwtToken);
                return Ok(new { message = "Gider silme kontrolü yapıldı.", result = controlResult });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Bir hata oluştu.", error = ex.Message });
            }
        }

        // DELETE /api/Gider/ControlDeleteById
        [HttpDelete("ControlDeleteById")]
        public async Task<IActionResult> ControlDeleteById([FromQuery] int id)
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
                var controlResult = await _giderService.ControlDeleteByIdAsync(id,jwtToken);
                return Ok(new { message = $"ID {id} ile gider silme kontrolü yapıldı.", result = controlResult });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Bir hata oluştu.", error = ex.Message });
            }
        }

        // GET /api/Gider/getbyid
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
                var result = await _giderService.GetByIdAsync(id,jwtToken);
                if (result == null)
                {
                    return NotFound(new { message = $"ID {id} ile gider bulunamadı." });
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Bir hata oluştu.", error = ex.Message });
            }
        }

        // POST /api/Gider/add
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] GiderAddDto giderDto)
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
                if (giderDto == null)
                {
                    return BadRequest(new { message = "Geçersiz gider verisi." });
                }

                await _giderService.AddAsync(giderDto,jwtToken);

                return Ok(new { message = "Gider başarıyla eklendi." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Bir hata oluştu.", error = ex.Message });
            }
        }

        // POST /api/Gider/addrange
        [HttpPost("addrange")]
        public async Task<IActionResult> AddRange([FromBody] GiderAddRangeDto giderler)
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
                if (giderler == null || !giderler.Giderler.Any())
                {
                    return BadRequest(new { message = "Eklemek için gider listesi boş olamaz." });
                }

                await _giderService.AddRangeAsync(giderler,jwtToken);  // Giderler doğru DTO tipine göre işlenir.

                return Ok(new { message = "Giderler başarıyla eklendi." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Bir hata oluştu.", error = ex.Message });
            }
        }

        // PUT /api/Gider/update
        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] GiderUpdateDto giderDto)
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
                if (giderDto == null)
                {
                    return BadRequest(new { message = "Geçersiz gider verisi." });
                }

                await _giderService.UpdateAsync(giderDto,jwtToken);

                return Ok(new { message = "Gider başarıyla güncellendi." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Bir hata oluştu.", error = ex.Message });
            }
        }

        // PUT /api/Gider/updaterange
        [HttpPut("updaterange")]
        public async Task<IActionResult> UpdateRange([FromBody] List<GiderUpdateDto> giderler)
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
            if (giderler == null || !giderler.Any())
            {
                return BadRequest(new { message = "Güncellenecek giderler bulunamadı." });
            }

            var rangeDto = new GiderUpdateRangeDto
            {
                Giderler = giderler
            };

            await _giderService.UpdateRangeAsync(rangeDto,jwtToken); 

            return Ok(new { message = "Giderler başarıyla güncellendi." });
        }

        // POST /api/Gider/delete
        [HttpPost("delete")]
        public async Task<IActionResult> Delete([FromBody] GiderDeleteDto giderDto)
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
                if (giderDto == null)
                {
                    return BadRequest(new { message = "Geçersiz gider verisi." });
                }

                await _giderService.DeleteAsync(giderDto,jwtToken);

                return Ok(new { message = "Gider başarıyla silindi." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Bir hata oluştu.", error = ex.Message });
            }
        }

        // DELETE /api/Gider/deletebyid
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
                await _giderService.DeleteByIdAsync(id,jwtToken);
                return Ok(new { message = $"ID {id} ile gider başarıyla silindi." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Bir hata oluştu.", error = ex.Message });
            }
        }

        // POST /api/Gider/deleterange
        [HttpPost("deleterange")]
        public async Task<IActionResult> DeleteRange([FromBody] GiderDeleteRangeDto giderler)
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
            if (giderler == null || !giderler.Giderler.Any())
            {
                return BadRequest(new { message = "Silinecek giderler bulunamadı." });
            }

            await _giderService.DeleteRangeAsync(giderler.Giderler,jwtToken);

            return Ok(new { message = "Birden fazla gider silindi." });
        }

    }
}
