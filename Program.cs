using WebApplication5;
using WebApplication5.Repositories;
using WebApplication5.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options => options.AddDefaultPolicy(policy => 
policy
.AllowAnyHeader()
.AllowAnyMethod()
.AllowAnyOrigin()
));

builder.Services.AddDbContext<ApplicationDbContext>();
builder.Services.AddScoped<IChocolateRepository, ChocolateRepository>();

builder.Services.AddScoped<RandomNumberGeneratorService>();

// Singleton, Scoped, Transient

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();

app.Run();
