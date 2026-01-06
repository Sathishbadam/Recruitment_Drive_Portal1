
using Microsoft.AspNetCore.Mvc;
using Recruitment_Drive_Portal1.Application.Services;
using Recruitment_Drive_Portal1.Domain.Models;
using OfficeOpenXml;


namespace Recruitment_Drive_Portal1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PanelRegistrationController : ControllerBase
    {
        private readonly PanelRegistrationService _service;

        public PanelRegistrationController(PanelRegistrationService service)
        {

            _service = service;
        }

        [HttpPost("register")]
        public async Task<IActionResult> PanelRegistration(RegisterPanel panel)
        {
            if (panel.AvailableDate < DateOnly.FromDateTime(DateTime.Today))
            {
                return BadRequest("Available date cannot be in the past.");
            }
            var paneldetails = await _service.RegisterPanel(panel);
            return Ok(paneldetails);
        }

        [HttpGet]
        public async Task<IActionResult> GetPanelDetalis(DateOnly? fromDate, DateOnly? toDate, string? skill, bool export = false)
        {
            var paneldetails=await _service.GetPanelDetails(fromDate, toDate, skill);
            if (!export)
                return Ok(paneldetails);
            return ExportToExcel(paneldetails);
        }
        private IActionResult ExportToExcel(List<RegisterPanel> panels)
        {
            using var package = new ExcelPackage();
            var sheet = package.Workbook.Worksheets.Add("Panels");

            // Header row
            sheet.Cells[1, 1].Value = "Panel Id";
            sheet.Cells[1, 2].Value = "Name";
            sheet.Cells[1, 3].Value = "Email";
            sheet.Cells[1, 4].Value = "Phone";
            sheet.Cells[1, 5].Value = "Designation";
            sheet.Cells[1, 6].Value = "Interviewer Type";
            sheet.Cells[1, 7].Value = "Interviewer Mode";
            sheet.Cells[1, 8].Value = "Experience";
            sheet.Cells[1, 9].Value = "Skills";
            sheet.Cells[1, 10].Value = "Available Date";
            sheet.Cells[1, 11].Value = "Created On";

            int row = 2;

            foreach (var p in panels)
            {
                sheet.Cells[row, 1].Value = p.PanelId;
                sheet.Cells[row, 2].Value = p.Name;
                sheet.Cells[row, 3].Value = p.Email;
                sheet.Cells[row, 4].Value = p.PhoneNumber;
                sheet.Cells[row, 5].Value = p.Designation;
                sheet.Cells[row, 6].Value = p.InterviewerType;
                sheet.Cells[row, 7].Value = p.InterviewerMode;

                
                sheet.Cells[row, 8].Value =
                    $"{p.ExperienceYears} Years {p.ExperienceMonths} Months";

                sheet.Cells[row, 9].Value = p.Skills;
                sheet.Cells[row, 10].Value = p.AvailableDate.ToString("yyyy-MM-dd");
                sheet.Cells[row, 11].Value = p.CreatedOn.ToString("yyyy-MM-dd HH:mm");

                row++;
            }

            if (sheet.Dimension != null)
                sheet.Cells[sheet.Dimension.Address].AutoFitColumns();

            return File(
                package.GetAsByteArray(),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                "PanelDetails.xlsx"
            );
        }




    }
}
