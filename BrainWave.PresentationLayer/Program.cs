using BrainWave.BusinessLayer.Abstract;
using BrainWave.BusinessLayer.Concrete;
using BrainWave.DataAccessLayer.Abstract;
using BrainWave.DataAccessLayer.Concrete;
using BrainWave.DataAccessLayer.EntityFramework;
using BrainWave.DataAccessLayer.Repostories;
using BrainWave.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<AppUser, AppRole>()
    .AddEntityFrameworkStores<Context>()
    .AddDefaultTokenProviders();

builder.Services.AddScoped<IProjectRequestDal, EfProjectRequestDal>();
builder.Services.AddScoped<IProjectRequestService, ProjectRequestManager>();
builder.Services.AddScoped<IFriendRequestService, FriendRequestManager>();
builder.Services.AddScoped<IFriendRequestDal, EfFriendRequestDal>();
builder.Services.AddScoped<ITaskRequestService, TaskRequestManager>();
builder.Services.AddScoped<ITaskRequestDal, EfTaskRequestDal>();

builder.Services.AddScoped<ProjectRepostory>();

var app = builder.Build();

// Create Roles
async Task CreateRoles(IServiceProvider serviceProvider)
{
    var roleManager = serviceProvider.GetRequiredService<RoleManager<AppRole>>();
    var userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();

    string[] roleNames = { "Admin", "Standart", "Mentor", "Menti" };
    IdentityResult roleResult;

    foreach (var roleName in roleNames)
    {
        var roleExist = await roleManager.RoleExistsAsync(roleName);
        if (!roleExist)
        {
            roleResult = await roleManager.CreateAsync(new AppRole { Name = roleName });
        }
    }

    // Here you could create a super user who will maintain the web app
    var poweruser = new AppUser
    {
        UserName = builder.Configuration["AppSettings:UserName"],
        Email = builder.Configuration["AppSettings:UserEmail"],
        Name = "Admin",
        Surname = "User"
    };

    string userPassword = builder.Configuration["AppSettings:UserPassword"];
    var user = await userManager.FindByEmailAsync(builder.Configuration["AppSettings:UserEmail"]);

    if (user == null)
    {
        var createPowerUser = await userManager.CreateAsync(poweruser, userPassword);
        if (createPowerUser.Succeeded)
        {
            await userManager.AddToRoleAsync(poweruser, "Admin");
        }
    }
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    CreateRoles(services).Wait();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
