using AutoMapper;
using Ecom4.Core.IRepository;
using Ecom4.Core.IService;
using Ecom4.Infrastructure.Data;
using Ecom4.Infrastructure.Repository;
using Ecom4.Infrastructure.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//  CORS 
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200") // رابط مشروع الأنجولار
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

//DB
builder.Services.AddDbContext<AppDbContext>(options =>
 options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//mapper
builder.Services.AddAutoMapper(typeof(Program));

//reposities
/*builder.Services.AddScoped<IImageMangmentService, ImageMangmentService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IPhotoRepository, PhotoRepository>();*/
builder.Services.AddScoped<IImageMangmentService, ImageMangmentService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseStatusCodePagesWithReExecute("/api/Errors/{0}");

app.UseHttpsRedirection();
app.UseCors("AllowAngularApp");
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
