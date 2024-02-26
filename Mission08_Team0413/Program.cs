using Microsoft.EntityFrameworkCore;
using Mission08_Team0413.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// add database
builder.Services.AddDbContext<TaskContext>(options =>
{
    // use connection we named in connection string
    options.UseSqlite(builder.Configuration["ConnectionStrings:TaskConnection"]);
}
);

// builds interface that sits with user on their machine
builder.Services.AddScoped<ITaskRepository, EFTaskRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
