using BadmintonRentingBusiness;
using BadmintonRentingData;
using BadmintonRentingData.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSession();
builder.Services.AddScoped<UnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ICustomerBusiness, CustomerBusiness>();
builder.Services.AddScoped<CustomerRepository>();
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
