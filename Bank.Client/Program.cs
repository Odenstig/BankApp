

using Bank.Client.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc(options => options.EnableEndpointRouting = false);
builder.Services.AddSession(options => options.IdleTimeout = TimeSpan.FromMinutes(15));
builder.Services.AddDistributedMemoryCache();
builder.Services.AddHttpContextAccessor();

builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IAccountService, AccountService>();
builder.Services.AddTransient<IBankService, BankService>();

builder.Services.AddHttpClient();

var app = builder.Build();

app.UseStaticFiles();
app.UseSession();

app.UseMvc(routes =>
{
    routes.MapRoute(
      name: "Default",
      template: "{controller}/{action}",
      new { controller = "Home", action = "Index"}
    );
});

app.Run();