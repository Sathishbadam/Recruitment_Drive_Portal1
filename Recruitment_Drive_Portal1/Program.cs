using OfficeOpenXml;
using Recruitment_Drive_Portal1.Application.Services;
using Recruitment_Drive_Portal1.Domain.Interfaces;
using Recruitment_Drive_Portal1.Infrastructure.Repos;


var builder = WebApplication.CreateBuilder(args);

ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddScoped<IPanelRegistration, PanelRegistrations>();
builder.Services.AddScoped<PanelRegistrationService>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazor",
        policy => policy
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowBlazor");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
