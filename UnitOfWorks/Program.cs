using Microsoft.EntityFrameworkCore;
using UnitOfWorks.Abstracts;
using UnitOfWorks.Concretes;
using UnitOfWorks.Context;
using UnitOfWorks.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MinimalConnectionString"));
});

builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapGet("GetCompanies", async (ICompanyRepository companyRepository) =>
{
    return Results.Ok(await companyRepository.GetAll().ToListAsync());
});

app.MapPost("CreateCompany", async (string name, ICompanyRepository companyRepository, IUnitOfWork unitOfWork) =>
{
    var company = new Company();
    company.Name = name;

    await companyRepository.AddAsync(company);
    await unitOfWork.CompleteAsync();

    return Results.NoContent();
});

app.Run();
