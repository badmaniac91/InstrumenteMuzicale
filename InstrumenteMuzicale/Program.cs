using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using InstrumenteMuzicale.Models;

var builder = WebApplication.CreateBuilder(args);

// Adaugă suport pentru Razor Pages
builder.Services.AddRazorPages();

// Configurarea bazei de date
builder.Services.AddDbContext<InstrumenteMuzicaleContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("InstrumenteMuzicaleContext")));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseStaticFiles();

app.UseAuthorization();
app.MapRazorPages();

app.Run();
