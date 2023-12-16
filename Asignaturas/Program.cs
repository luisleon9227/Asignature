using Asignaturas;
using Asignaturas.Services;
using Asignaturas.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSqlServer<AsignaturesContext>("Data Source=LEON802744-11;Initial Catalog=Asignature;User id=sa;password=luisleon; TrustServerCertificate=True;");
builder.Services.AddScoped<IUser, User>();
builder.Services.AddScoped<IAsignature, Asignature>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

//app.UseWelcomePage();

app.MapControllers();

app.Run();
