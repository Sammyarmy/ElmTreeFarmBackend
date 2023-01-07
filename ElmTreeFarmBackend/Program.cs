using ElmTreeFarmBackend.Commands;

var appBuilder = WebApplication.CreateBuilder(args);

// Add services to the container.



ConfigureServices(appBuilder.Services);

void ConfigureServices(IServiceCollection services)
{
    services.AddControllers();
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();
    services.AddCors(options =>
    {
        options.AddPolicy("AllowSpecificOrigin",
            builder => builder.WithOrigins("https://elmtreefarmfrontend.azurewebsites.net"));
    });
    
    services.AddTransient<IWeatherApi, WeatherApi>();
}

var app = appBuilder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors();

app.MapControllers();

app.Run();
