using Recruitment_Drive_Portal1.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruitment_Drive_Portal1.Application.Interfaces
{
    public interface IPanelRegistrationService
    {
        Task<RegisterPanel> RegisterPanel(RegisterPanel panel);
        Task<List<RegisterPanel>> GetPanelDetails(DateOnly? fromDate, DateOnly? toDate, string? skill);
    }
}
