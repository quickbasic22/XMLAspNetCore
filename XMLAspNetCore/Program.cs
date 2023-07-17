using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using XMLAspNetCore.Data;
using XMLAspNetCore.Models;



var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddRazorPages();

// Add services to the container.

builder.Services.AddDbContext<AdventureWorks2012Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AdventureWorks2012Context") ?? throw new InvalidOperationException("Connection string 'AdventureWorksContext' not found.")));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
