using Recruitment_Drive_Portal1.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruitment_Drive_Portal1.Domain.Interfaces
{
    public interface IPanelRegistration
    {
        Task<RegisterPanel> PanelRegistration(RegisterPanel panel);
        Task<List<RegisterPanel>> GetPanelRegistrationDetails(DateOnly? fromDate, DateOnly? toDate, string? skill);
    }
}
