using Recruitment_Drive_Portal1.Domain.Interfaces;
using Recruitment_Drive_Portal1.Domain.Models;


namespace Recruitment_Drive_Portal1.Application.Services
{
    public class PanelRegistrationService
    {
        private readonly IPanelRegistration _repo;

        public PanelRegistrationService(IPanelRegistration repo)
        {
            _repo = repo;
        }

        public async Task<RegisterPanel> RegisterPanel(RegisterPanel panel)
        {
            var registerdetails = await _repo.PanelRegistration(panel);
            return registerdetails;
        }

        public async Task<List<RegisterPanel>> GetPanelDetails(DateOnly? fromDate, DateOnly? toDate, string? skill)
        {
            var registerdetails= await _repo.GetPanelRegistrationDetails(fromDate, toDate, skill);
            return registerdetails;
        }
    }
}
