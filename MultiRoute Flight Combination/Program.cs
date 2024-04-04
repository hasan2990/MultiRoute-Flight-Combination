
using MultiRoute_Flight_Combination.Repositories.Implementations;
using MultiRoute_Flight_Combination.Repositories.Interfaces;
using MultiRoute_Flight_Combination.Services.Implementations;
using MultiRoute_Flight_Combination.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IFlightRepository, FlightRepository>();
builder.Services.AddTransient<IFlightService, FlightService>();

var app = builder.Build();
app.UseCors(policy => { policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); });


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
