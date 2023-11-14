using System.Net.Http.Json;
using ValuationApp.Services.Contract;
using ValuationApp.ValuationDto;

namespace ValuationApp.Web.Requests
{
    public class ApiVesselService : IVesselService
    {
        protected readonly HttpClient _httpClient;

        public ApiVesselService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<int> Create(VesselDto vessel)
        {
            throw new NotImplementedException();
        }

        public Task<VesselDto> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<VesselDto>> GetAll() {

            var response = await _httpClient.GetFromJsonAsync<List<VesselDto>>($"Vessel");
            return response ?? throw new HttpRequestException("Couldn't get vessels");
        }

        public Task<int> Update(VesselDto vessel)
        {
            throw new NotImplementedException();
        }
    }
}
