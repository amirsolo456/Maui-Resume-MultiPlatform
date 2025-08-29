
using Resume.Application.Interfaces;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Collections.Generic;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();

//builder.Services.AddDbContext<ResumeDbContext>(options =>
//    options.UseSqlServer("DefaultConnection"));


//builder.Services.AddTransient(typeof(IEducationService));
//builder.Services.AddScoped<IEducationService,>();

//INSERT INTO[dbo].[NavigationItems] (Id, Title, Icon, KeyName)
//VALUES
//(NEWID(), N'About Me', N'myprofilepic.jpg', N'aboutme'),
//(NEWID(), N'Skills',    N'skills.png', N'skills'),
//(NEWID(), N'Experience', N'experience.png', N'experience'),
//(NEWID(), N'Education', N'education.png', N'education'),
//(NEWID(), N'Projects', N'projects.png', N'projects'),
//(NEWID(), N'Contact', N'contact.png', N'contact');

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.AddInfrastructureServices();
var app = builder.Build();

app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{    // فعال کردن Swagger UI
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Resume API V1");
    });
    app.MapOpenApi();
}
 
//app.UseAuthorization();  
app.MapControllers();
app.UseHttpsRedirection();
app.MapFallbackToFile("index.html");
app.UseExceptionHandler(options => { });
 
app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
