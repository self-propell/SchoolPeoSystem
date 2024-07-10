var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//builder.Services.AddAuthentication(CookieAuthenticationDefaults.Au);
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

//app.UseAuthentication();    // 鉴权 中间件
app.UseAuthorization();     // 授权 中间件

app.MapControllerRoute(
    name: "default",
     pattern: "{controller=LoginPage}/{action=Index}");

//app.MapControllerRoute(
//    name: "SystemAdminIndex",
//     pattern: "{controller=SystemAdmin}/{action=SystemAdminIndex}/{page=Main}");

app.Run();
