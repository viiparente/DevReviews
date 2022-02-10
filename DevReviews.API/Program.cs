using DevReviews.API.Persistence;
using DevReviews.API.Profiles;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DevReviewsCs");

builder.Services
    .AddDbContext<DevReviewsDbContext>(o =>
        o.UseSqlServer(connectionString));

//builder.Services
//    .AddDbContext<DevReviewsDbContext>(o =>
//        o.UseInMemoryDatabase("DevReviewsCs"));

builder.Services.AddAutoMapper(typeof(ProductProfile));

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
