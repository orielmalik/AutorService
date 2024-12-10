using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[assembly: ApiController]
var builder = WebApplication.CreateBuilder(args);

// הגדרת ה-DbContext ושירותים אחרים
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql("Host=localhost;Port=5432;Database=mydb;Username=myuser;Password=mypassword"));

// הוספת שירותים נוספים כמו ה-CRUD service
builder.Services.AddScoped<AuthorCrud>();

builder.Services.AddControllers();

var app = builder.Build();
var dockerComposeProcess = new Process
{
    StartInfo = new ProcessStartInfo
    {
        FileName = "docker-compose", // הפקודה הנכונה
        Arguments = "up -d",  // להריץ ב-background (detached mode)
        UseShellExecute = false,
        RedirectStandardOutput = true,
        RedirectStandardError = true
    }
};
dockerComposeProcess.Start();

// בדיקת מצב
var output = dockerComposeProcess.StandardOutput.ReadToEnd();
var error = dockerComposeProcess.StandardError.ReadToEnd();
Console.WriteLine("Output: " + output);
Console.WriteLine("Error: " + error);

app.Lifetime.ApplicationStopping.Register(() =>
{
    var dockerComposeDownProcess = new Process
    {
        StartInfo = new ProcessStartInfo
        {
            FileName = "docker-compose", 
            Arguments = "down", 
            UseShellExecute = false,
            RedirectStandardOutput = true,
            RedirectStandardError = true
        }
    };

    dockerComposeDownProcess.Start();
    dockerComposeDownProcess.WaitForExit(); 
});

app.MapGet("/", () => { return "Application is running"; });
app.MapControllers();

app.Run();
