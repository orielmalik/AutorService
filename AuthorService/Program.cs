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

// הפעלת המיגרציות והעדכון של בסיס הנתונים
var processAddMigration = new Process
{
    StartInfo = new ProcessStartInfo
    {
        FileName = "dotnet",
        Arguments = "ef migrations add InitialCreate", // הפקודה להוספת מיגרציה
        UseShellExecute = false,
        RedirectStandardOutput = true,
        RedirectStandardError = true
    }
};
processAddMigration.Start();
processAddMigration.WaitForExit(); // לחכות עד שהפקודה תושלם

var processUpdateDatabase = new Process
{
    StartInfo = new ProcessStartInfo
    {
        FileName = "dotnet",
        Arguments = "ef database update", // הפקודה לעדכון בסיס הנתונים
        UseShellExecute = false,
        RedirectStandardOutput = true,
        RedirectStandardError = true
    }
};
processUpdateDatabase.Start();
processUpdateDatabase.WaitForExit(); // לחכות עד שהפקודה תושלם

// הפעלת Docker Compose
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

// רישום הפסקה של Docker Compose כשסוגרים את האפליקציה
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
    dockerComposeDownProcess.WaitForExit(); // לחכות עד שהפקודה תושלם
});

app.MapGet("/", () => { return "Application is running"; });
app.MapControllers();

app.Run();
