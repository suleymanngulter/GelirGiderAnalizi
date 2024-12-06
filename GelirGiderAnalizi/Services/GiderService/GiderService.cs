using AutoMapper;
using GelirGiderAnalizi.Dtos.GiderDto;
using GelirGiderAnalizi.Models;
using GelirGiderAnalizi.Services.AuthService;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using GelirGiderAnalizi.Models.GelirGiderAnalizi.Models;
using Newtonsoft.Json.Linq;

namespace GelirGiderAnalizi.Services.GiderService
{
    public class GiderService : IGiderService
    {
        private readonly IMapper _mapper;
        private readonly HttpClient _httpClient;

        public GiderService(IMapper mapper, HttpClient httpClient)
        {
            _mapper = mapper;
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://apiv3.bilsoft.com");
        }

        //Gider getall
        public async Task<List<GiderGetAllDto>> GetAllGiderlerAsync(GiderGetAllDto filtre,string token)
        {
            var content = new StringContent(JsonConvert.SerializeObject(filtre), Encoding.UTF8, "application/json");
            _httpClient.DefaultRequestHeaders.Add("Authorization", token);
            var response = await _httpClient.PostAsync("/api/Gider/getall", content);

            var serializedData = JsonConvert.SerializeObject(filtre);
            Console.WriteLine(serializedData);


            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var giderler = JsonConvert.DeserializeObject<List<GiderModel>>(jsonResponse);
                return _mapper.Map<List<GiderGetAllDto>>(giderler);
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Error: {response.StatusCode}, Content: {errorContent}");
            }

            return null!;
        }

        //Gider controldelete
        public async Task<GiderControlDeleteDto> ControlDeleteAsync(GiderModel gider,string token)
        {
            var content = new StringContent(JsonConvert.SerializeObject(gider), Encoding.UTF8, "application/json");
            _httpClient.DefaultRequestHeaders.Add("Authorization", token);
            var response = await _httpClient.PostAsync("/api/Gider/ControlDelete", content);

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<GiderControlDeleteDto>(jsonResponse);
                return _mapper.Map<GiderControlDeleteDto>(result);
            }

            return null!;
        }


        //Gider controldeletebyid
        public async Task<GiderControlDeleteByIdDto> ControlDeleteByIdAsync(int id,string token)
        {
            _httpClient.DefaultRequestHeaders.Add("Authorization", token);
            var response = await _httpClient.DeleteAsync($"/api/Gider/ControlDeleteById?id={id}");

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<GiderControlDeleteByIdDto>(jsonResponse);
                return _mapper.Map<GiderControlDeleteByIdDto>(result);
            }

            return null!;
        }

        //Gider getbyid
        public async Task<GiderGetByIdDto> GetByIdAsync(int id,string token)
        {
            _httpClient.DefaultRequestHeaders.Add("Authorization", token);
            var response = await _httpClient.GetAsync($"/api/Gider/getbyid?id={id}");

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<GiderGetByIdDto>(jsonResponse);
                return _mapper.Map<GiderGetByIdDto>(result);
            }

            return null!;
        }

        //Gider add
        public async Task AddAsync(GiderAddDto giderDto,string token)
        {
            var content = new StringContent(JsonConvert.SerializeObject(giderDto), Encoding.UTF8, "application/json");
            _httpClient.DefaultRequestHeaders.Add("Authorization", token);
            await _httpClient.PostAsync("/api/Gider/add", content);
        }

        //Gider addrange
        public async Task AddRangeAsync(GiderAddRangeDto giderlerDto,string token)
        {
            var content = new StringContent(JsonConvert.SerializeObject(giderlerDto), Encoding.UTF8, "application/json");
            _httpClient.DefaultRequestHeaders.Add("Authorization", token);
            await _httpClient.PostAsync("/api/Gider/addrange", content);
        }

        //Gider update
        public async Task UpdateAsync(GiderUpdateDto giderDto,string token)
        {
            var content = new StringContent(JsonConvert.SerializeObject(giderDto), Encoding.UTF8, "application/json");
            _httpClient.DefaultRequestHeaders.Add("Authorization", token);
            await _httpClient.PutAsync("/api/Gider/update", content);
        }


        //Gider updaterange
        public async Task UpdateRangeAsync(GiderUpdateRangeDto giderlerDto,string token)
        {
            var content = new StringContent(JsonConvert.SerializeObject(giderlerDto), Encoding.UTF8, "application/json");
            _httpClient.DefaultRequestHeaders.Add("Authorization", token);
            await _httpClient.PutAsync("/api/Gider/updaterange", content);
        }

        //Gider delete
        public async Task DeleteAsync(GiderDeleteDto giderDto,string token)
        {
            var content = new StringContent(JsonConvert.SerializeObject(giderDto), Encoding.UTF8, "application/json");
            _httpClient.DefaultRequestHeaders.Add("Authorization", token);
            await _httpClient.PostAsync("/api/Gider/delete", content);
        }

        //Gider deletebyid
        public async Task DeleteByIdAsync(int id,string token)
        {
            _httpClient.DefaultRequestHeaders.Add("Authorization", token);
            await _httpClient.DeleteAsync($"/api/Gider/deletebyid?id={id}");
        }

        //Gider deleterange
        public async Task DeleteRangeAsync(List<GiderDeleteDto> giderler,string token)
        {
            foreach (var gider in giderler)
            {
                var content = new StringContent(JsonConvert.SerializeObject(giderler), Encoding.UTF8, "application/json");
                _httpClient.DefaultRequestHeaders.Add("Authorization", token);
                await _httpClient.PostAsync("/api/Gider/deleterange", content);
            }
        }
    }
}
