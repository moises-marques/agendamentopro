using AgendamentoPro.Data;
using Microsoft.EntityFrameworkCore;
using AgendamentoPro.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// CONFIGURAÇÃO DO BANCO DE DADOS (TEM QUE SER AQUI)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=agendamento.db"));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    if (!db.Services.Any())
    {
        db.Services.AddRange(
            new Service { Name = "Corte de Cabelo", DurationMinutes = 30, Price = 40 },
            new Service { Name = "Barba", DurationMinutes = 20, Price = 25 },
            new Service { Name = "Corte + Barba", DurationMinutes = 50, Price = 60 }
        );

        db.SaveChanges();
    }
}


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
