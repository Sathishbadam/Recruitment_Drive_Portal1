using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Recruitment_Drive_Portal1.Domain.Interfaces;
using Recruitment_Drive_Portal1.Domain.Models;
using System.Data;

namespace Recruitment_Drive_Portal1.Infrastructure.Repos
{
    public class PanelRegistrations :IPanelRegistration
    {
        private readonly string _connectionString;

        public PanelRegistrations(IConfiguration configuration)
        {
            _connectionString = "Server=LAPTOP-8VI8V3LR\\SQLEXPRESS;Database=Recruitment_Drive_Portal;Trusted_Connection=True;TrustServerCertificate=True;";
        }

        public async  Task<List<RegisterPanel>> GetPanelRegistrationDetails(DateTime? fromDate, DateTime? toDate, string? skill)
        {
            var panels = new List<RegisterPanel>();

            using var con = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("sp_GetPanelRegistrationsDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@FromDate", fromDate ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@ToDate", toDate ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Skill", skill ?? (object)DBNull.Value);

            await con.OpenAsync();

            using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                panels.Add(new RegisterPanel
                {
                    PanelId = (int)reader["PanelId"],
                    Name = reader["Name"].ToString(),
                    Email = reader["Email"].ToString(),
                    PhoneNumber = reader["PhoneNumber"].ToString(),
                    Skills = reader["Skills"].ToString(),
                    Experience = (decimal)reader["Experience"],
                    AvailableDate = (DateOnly)reader["AvailableDate"],
                    CreatedOn = (DateTime)reader["CreatedOn"]
                });
            }

            return panels;
        }

        public async Task<RegisterPanel> PanelRegistration(RegisterPanel panel)
        {
            using SqlConnection con = new SqlConnection(_connectionString);
            using SqlCommand cmd = new SqlCommand("sp_RegisterPanel", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Name", panel.Name);
            cmd.Parameters.AddWithValue("@Email", panel.Email);
            cmd.Parameters.AddWithValue("@PhoneNumber", panel.PhoneNumber);
            cmd.Parameters.AddWithValue("@Skills", panel.Skills);
            cmd.Parameters.AddWithValue("@Experience", panel.Experience);
            cmd.Parameters.AddWithValue("@AvailableDate", panel.AvailableDate);

            await con.OpenAsync();
            await cmd.ExecuteNonQueryAsync();
            return panel;
        }


    }
}
