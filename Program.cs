using CqrsMediatRExample.Data;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Add the mediatR Dependency: 
builder.Services.AddMediatR(typeof(Program));

//Implements our fake dummy data for the rest of the class of the application as a service. 
builder.Services.AddSingleton<FakeDataStore>();


builder.Services.AddControllers();
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
