using TRPBin.db;
using TRPBin.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// builder.Services.AddScoped<TestLuaService>();

builder.Services.AddScoped<ILuaFactory, LuaFactory>();
builder.Services.AddScoped<ITRPSerializer, TRPSerializer>();
builder.Services.AddScoped<ITRPProfileService, TRPProfileService>();
builder.Services.AddScoped<ApplicationContext>();

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

// var scope = app.Services.CreateAsyncScope();
// var service = scope.ServiceProvider.GetRequiredService<TestLuaService>();

// service.TestMoonSharp();
