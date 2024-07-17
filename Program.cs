



using Insurance_Project.Converters;
using Insurance_Project.Models;
using Insurance_Project.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors();

var connectionString = builder.Configuration["ConnectionStrings:DefaultConnection"];

builder.Services.AddDbContext<DatabaseContext>(option => option.UseLazyLoadingProxies().UseSqlServer(connectionString));//thao tac database

//database-- > EFcore(databaseContext)--->Service--->controllers

builder.Services.AddScoped<InsuraceService, InsuranceServiceImpl>();
builder.Services.AddScoped<CustomerService, CustomerServiceImpl>();
builder.Services.AddScoped<ContractService, ContractServiceImpl>();
builder.Services.AddScoped<PaymentService, PaymentServiceImpl>();
builder.Services.AddScoped<HistoryService, HistoryServiceImpl>();


builder.Services.AddControllers().AddJsonOptions(option =>
{
    option.JsonSerializerOptions.Converters.Add(new DateConverter());
});//converter



var app = builder.Build();
app.UseCors(builder => builder
                .AllowAnyHeader()
                .AllowAnyMethod()
                .SetIsOriginAllowed((host) => true)
                .AllowCredentials()
            );

app.UseStaticFiles();//cau hinh wwwroot
app.UseAuthorization();



app.MapControllers();

app.Run();

