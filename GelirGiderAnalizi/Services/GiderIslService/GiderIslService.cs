using AutoMapper;
using GelirGiderAnalizi.Dtos.GiderIslDto;
using GelirGiderAnalizi.Models;
using GelirGiderAnalizi.Models.GelirGiderAnalizi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace GelirGiderAnalizi.Services
{
    public class GiderIslService : IGiderIslService
    {
        private readonly IMapper _mapper;
        private readonly HttpClient _httpClient;

        public GiderIslService(IMapper mapper, HttpClient httpClient)
        {
            _mapper = mapper;
            _httpClient = httpClient;
        }

        //GiderIslService getall
        public async Task<List<GelirGiderIslemYapDto>> GetAllGiderIslAsync(GiderIslGetAllDto dto, string token)
        {
            if (_httpClient == null)
            {
                throw new InvalidOperationException("HttpClient is not initialized.");
            }
            //token 
            var content = new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token); 

            var response = await _httpClient.PostAsync("/api/GiderIsl/getall", content);

            if (response.IsSuccessStatusCode)
            {
                //json al ve deserilize et
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<GiderIslModel>>(jsonResponse);
                return _mapper.Map<List<GelirGiderIslemYapDto>>(result);
            }
            else
            {
                Console.WriteLine($"API Error: {response.StatusCode}");
                var errorResponse = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Error Details: {errorResponse}");
            }

            return null!;
        }

        //GiderIslService getbyid
        public async Task<GiderIslGetByIdDto> GetByIdAsync(int id, string token)
        {
            //token
            _httpClient.DefaultRequestHeaders.Add("Authorization", token);
            var response = await _httpClient.GetAsync($"/api/GiderIsl/getbyid?id={id}");

            if (response.IsSuccessStatusCode)
            {
                //json al ve deserilize et
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<GiderIslModel>(jsonResponse);
                return _mapper.Map<GiderIslGetByIdDto>(result);
            }
            else
            {
                Console.WriteLine(response.StatusCode);
            }

            return null!;
        }

        //GiderIslService add
        public async Task AddAsync(GiderIslAddDto dto,string token)
        {
            var content = new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json");
            _httpClient.DefaultRequestHeaders.Add("Authorization", token);
            await _httpClient.PostAsync("/api/GiderIsl/add", content);
        }

        //GiderIslService addrange
        public async Task AddRangeAsync(GiderIslAddRangeDto dto,string token)
        {
            var content = new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json");
            _httpClient.DefaultRequestHeaders.Add("Authorization", token);
            await _httpClient.PostAsync("/api/GiderIsl/addrange", content);
        }

        //GiderIslService update
        public async Task UpdateAsync(GiderIslUpdateDto dto, string token)
        {
            var content = new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json");
            _httpClient.DefaultRequestHeaders.Add("Authorization", token);
            await _httpClient.PutAsync("/api/GiderIsl/update", content);
        }

        //GiderIslService updaterange
        public async Task UpdateRangeAsync(GiderIslUpdateRangeDto dto, string token)
        {
            var content = new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json");
            _httpClient.DefaultRequestHeaders.Add("Authorization", token);
            await _httpClient.PutAsync("/api/GiderIsl/updaterange", content);
        }

        //GiderIslService deletebyıd
        public async Task DeleteByIdAsync(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Add("Authorization", token);
            await _httpClient.DeleteAsync($"/api/GiderIsl/deletebyid?id={id}");
        }

        //GiderIslService deleterange
        public async Task DeleteRangeAsync(GiderIslDeleteRangeDto dto, string token)
        {
            var content = new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json");
            _httpClient.DefaultRequestHeaders.Add("Authorization", token);
            await _httpClient.PostAsync("/api/GiderIsl/deleterange", content);
        }

        //GiderIslService gelirgiderislemyap
        public async Task GelirGiderIslemYapAsync(GelirGiderIslemYapDto dto, string token)
        {
            var content = new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json");
            _httpClient.DefaultRequestHeaders.Add("Authorization", token);
            await _httpClient.PostAsync("/api/GiderIsl/gelirgiderislemyap", content);
        }

        //GiderIslService delete
        public async Task GiderIslDeleteAsync(GiderIslDeleteDto dto, string token)
        {
            var content = new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json");
            _httpClient.DefaultRequestHeaders.Add("Authorization", token);
            await _httpClient.PostAsync("/api/GiderIsl/giderisldelete", content);
        }
    }
}
