using BookManagementAPI.Models;
using BookManagementAPI.Repositories;
using BookManagementAPI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//repositories added
builder.Services.AddTransient<IBookMgmtRepository, BookMgmtRepository>();
builder.Services.AddTransient<ILibraryMemberRepository, LibraryMemberRepository>();
builder.Services.AddTransient<ILoanRepository, LoanRepository>();

//services added
builder.Services.AddTransient<IBookMgmtService, BookMgmtService>();
builder.Services.AddTransient<ILibraryMemberService, LibraryMemberService>();
builder.Services.AddTransient<ILoanService, LoanService>();


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

app.Run();