using DevReviews.API.Persistence;
using DevReviews.API.Persistence.Repositories;
using DevReviews.API.Profiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DevReviewsCs");

builder.Services
    .AddDbContext<DevReviewsDbContext>(o =>
        o.UseSqlServer(connectionString));

//builder.Services
//    .AddDbContext<DevReviewsDbContext>(o =>
//        o.UseInMemoryDatabase("DevReviewsCs"));

builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddAutoMapper(typeof(ProductProfile));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "DevReviews API",
        Version = "v1",
        Contact = new OpenApiContact
        {
            Name = "Vinicius Parente",
            Email = "vd.parente@hotmail.com",
            Url = new Uri("https://www.linkedin.com/in/viiparente/")
        }
    });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);

});
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
