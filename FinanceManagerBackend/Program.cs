using FinanceManagerBackend.Data;
using FinanceManagerBackend.Services;
using Microsoft.EntityFrameworkCore;

using static FinanceManagerBackend.Services.EmailService;

var builder = WebApplication.CreateBuilder(args);

// Konfiguriere Kestrel zum Laden des SSL-Zertifikats
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(5001, listenOptions =>
    {
        listenOptions.UseHttps("localhost.pfx", "dev");
    });
});

// Lade SMTP-Einstellungen
builder.Services.Configure<SmtpSettings>(builder.Configuration.GetSection("SmtpSettings"));
builder.Services.AddTransient<EmailService>();


// Add services to the container.
builder.Services.AddControllers();

//Connection to SQL Server Database
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
