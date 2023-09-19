using LMS.Data;
using LMS.Models;
using LMS.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<LmsContext>(options =>
       options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); 
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IEmployeeLoanCardService, EmployeeLoanCardService>();
builder.Services.AddScoped<IDisplayAllItemsPurchasedService, DisplayAllItemsPurchasedService>();
builder.Services.AddScoped<IAdminLoanCardManagementService, AdminLoanCardManagementService>();
builder.Services.AddScoped<EmployeeProvider>();
builder.Services.AddScoped<LoanCardProvider>();
builder.Services.AddScoped<ItemsPurchasedProvider>();
builder.Services.AddScoped<AdminLoanCardManagementProvider>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
builder.Services.AddCors();
app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();
app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
app.MapControllers();

app.Run();
