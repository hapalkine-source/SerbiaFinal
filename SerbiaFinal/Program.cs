// Подключаем работу с базой данных
using Microsoft.EntityFrameworkCore;
using SerbiaFinal;
var builder = WebApplication.CreateBuilder(args);

// Добавляем поддержку контроллеров
builder.Services.AddControllers();

// Настраиваем Swagger (то, чего не хватало в шаблоне 2026)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddCors(options => {
    options.AddPolicy("AllowAll", policy => {
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

var app = builder.Build();

// Включаем визуальный интерфейс Swagger, если мы в режиме разработки
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.UseCors("AllowAll");
app.UseDefaultFiles(); // Чтобы сервер искал index.html сам
app.UseStaticFiles();  // Чтобы сервер разрешил отдавать файлы из папки wwwroot

app.MapControllers();

app.Run();
