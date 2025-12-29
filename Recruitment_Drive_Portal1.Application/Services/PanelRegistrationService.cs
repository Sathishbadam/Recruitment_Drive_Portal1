using Recruitment_Drive_Portal1.Domain.Interfaces;
using Recruitment_Drive_Portal1.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
