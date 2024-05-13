using BrainWave.BusinessLayer.Abstract;
using BrainWave.BusinessLayer.Concrete;
using BrainWave.DataAccessLayer.Abstract;
using BrainWave.DataAccessLayer.Concrete;
using BrainWave.DataAccessLayer.EntityFramework;
using BrainWave.EntityLayer.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<Context>();
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<Context>();

builder.Services.AddScoped<IProjectRequestDal, EfProjectRequestDal>();
builder.Services.AddScoped<IProjectRequestService, ProjectRequestManager>();

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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
