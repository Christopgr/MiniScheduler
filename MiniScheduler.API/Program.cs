using Microsoft.EntityFrameworkCore;
using MiniScheduler.DataAccessLayer.Repositories;
using MiniScheduler.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MiniSchedulerContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MiniSchedulerDb")));

builder.Services.AddScoped<IEmployRepository, EmployRepository>();
builder.Services.AddScoped<ISkillRepository, SkillRepository>();

builder.Services.AddCors();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<MiniSchedulerContext>();
        DataSeeder.Initialize(context);
    }
    catch (Exception)
    {
        Console.WriteLine("An error occurred while seeding the database.");
    }
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:3000"));

app.Run();
