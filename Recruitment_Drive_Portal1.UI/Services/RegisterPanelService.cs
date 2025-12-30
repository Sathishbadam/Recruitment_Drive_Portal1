using Recruitment_Drive_Portal1.Shared.Models;
using Recruitment_Drive_Portal1.UI.Interfaces;
using System.Net.Http.Json;
using Microsoft.AspNetCore.WebUtilities;


namespace Recruitment_Drive_Portal1.UI.Services
{
    public class RegisterPanelService : IRegisterPanel
    {
        private readonly HttpClient _http;

        public RegisterPanelService(HttpClient http)
        {
            _http = http;
        }


        public async Task<List<RegisterPanelDTO>> GetPanelDetailsAsync(DateOnly? fromDate,DateOnly? toDate,string? skill)
        {
            var queryParams = new Dictionary<string, string?>();

            if (fromDate.HasValue)
                queryParams.Add("fromDate", fromDate.Value.ToString("yyyy-MM-dd"));

            if (toDate.HasValue)
                queryParams.Add("toDate", toDate.Value.ToString("yyyy-MM-dd"));

            if (!string.IsNullOrWhiteSpace(skill))
                queryParams.Add("skill", skill);

            var url = QueryHelpers.AddQueryString("https://localhost:7212/api/PanelRegistration", queryParams);

            return await _http.GetFromJsonAsync<List<RegisterPanelDTO>>(url)
                   ?? new List<RegisterPanelDTO>();
        }
        public async Task<byte[]> DownloadPanelDetailsAsync(DateOnly? fromDate,DateOnly? toDate,string? skill)
        {
            var queryParams = new Dictionary<string, string?>
    {
        { "export", "true" }  
    };

            if (fromDate.HasValue)
                queryParams.Add("fromDate", fromDate.Value.ToString("yyyy-MM-dd"));

            if (toDate.HasValue)
                queryParams.Add("toDate", toDate.Value.ToString("yyyy-MM-dd"));

            if (!string.IsNullOrWhiteSpace(skill))
                queryParams.Add("skill", skill);

            var url = QueryHelpers.AddQueryString("https://localhost:7212/api/PanelRegistration",queryParams);
            return await _http.GetByteArrayAsync(url);
        }

        public async Task<RegisterPanelDTO> RegisterPanelAsync(RegisterPanelDTO panelDTO)
        {
            var response = await _http.PostAsJsonAsync("https://localhost:7212/api/PanelRegistration/register", panelDTO);
            return panelDTO;
        }
    }
}
