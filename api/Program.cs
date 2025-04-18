using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy => {
        policy.AllowAnyOrigin();
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
    });
});
builder.Services.AddDbContext<App.Models.DataContext>(options => options.UseMySQL(builder.Configuration.GetConnectionString("Database")));
var app = builder.Build();
app.UseCors();
app.UseRouting();
app.MapControllers();
app.Run();