using Recruitment_Drive_Portal1.Shared.Models;

namespace Recruitment_Drive_Portal1.UI.Interfaces
{
    public interface IRegisterPanel
    {
        Task<RegisterPanelDTO> RegisterPanelAsync(RegisterPanelDTO panelDTO);

        Task<List<RegisterPanelDTO>> GetPanelDetailsAsync(DateOnly? fromDate, DateOnly? toDate, string? skill);

        Task<byte[]> DownloadPanelDetailsAsync(DateOnly? fromDate, DateOnly? toDate, string? skill);

    }
}
