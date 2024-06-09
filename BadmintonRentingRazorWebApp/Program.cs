using BadmintonRentingBusiness;
using BadmintonRentingData;
using BadmintonRentingData.Base;
using BadmintonRentingData.Model;
using BadmintonRentingData.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<Net1702_PRN221_BadmintonRentingContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<BadmintonFieldReposiory>();
builder.Services.AddScoped<GenericRepository<BadmintonField>, BadmintonFieldReposiory>();
builder.Services.AddSession();
builder.Services.AddScoped<IBookingBadmintonFieldScheduleBusiness, BookingBadmintonFieldScheduleBusiness>();
builder.Services.AddScoped<UnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ICustomerBusiness, CustomerBusiness>();
builder.Services.AddScoped<CustomerRepository>();
builder.Services.AddScoped<IScheduleBusiness, ScheduleBusiness>();
builder.Services.AddScoped<ScheduleRepository>();
//builder.Services.AddMvc().AddRazorPagesOptions(options => options.Conventions.AddPageRoute("/FieldScheduleIndex", ""));
builder.Services.AddRazorPages();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();
app.MapControllerRoute(
    name: "customer",
    pattern: "Customer/{action=Index}/{id?}",
    defaults: new { controller = "CustomerView", action = "Index" });

app.UseSession();

app.Run();
