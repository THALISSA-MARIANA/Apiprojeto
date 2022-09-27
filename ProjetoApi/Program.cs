using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ProjetoApi.Data;
using ProjetoApi;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ProjetoApiContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ProjetoApiContext") ?? throw new InvalidOperationException("Connection string 'ProjetoApiContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();
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
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapCadastroEndpoints();

app.MapAnuncioEndpoints();

app.MapCandidaturaEndpoints();

app.MapHistoricoCandidaturaEndpoints();


app.Run();