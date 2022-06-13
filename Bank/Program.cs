using Bank.Core.Interfaces;
using Bank.Core.Services;
using Bank.Data.Auth;
using Bank.Data.Interfaces;
using Bank.Data.Models;
using Bank.Data.Repos;
using Bank.Domain.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.WithOrigins("http://localhost:3000")
                  .WithMethods("PUT", "DELETE", "GET", "POST")
                  //.WithHeaders("X-Requested-With", "content-type")
                  .AllowAnyHeader();
        });
});

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please insert JWT with Bearer into field",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
   {
     new OpenApiSecurityScheme
     {
       Reference = new OpenApiReference
       {
         Type = ReferenceType.SecurityScheme,
         Id = "Bearer"
       }
      },
      new string[] { }
    }
  });
});


builder.Services.AddTransient<IAccountRepo, AccountRepo>();
builder.Services.AddTransient<IAccountService, AccountService>();

builder.Services.AddTransient<ICustomerRepo, CustomerRepo>();
builder.Services.AddTransient<ICustomerService, CustomerService>();

builder.Services.AddTransient<IDispositionRepo, DispositionRepo>();
builder.Services.AddTransient<IDispositionService, DispositionService>();

builder.Services.AddTransient<IAccountTypeRepo, AccountTypeRepo>();
builder.Services.AddTransient<IAccountTypeService, AccountTypeService>();

builder.Services.AddTransient<ILoanRepo, LoanRepo>();
builder.Services.AddTransient<ILoanService, LoanService>();

builder.Services.AddTransient<ITransactionRepo, TransactionRepo>();
builder.Services.AddTransient<ITransactionService, TransactionService>();

//builder.Services.AddTransient<IBidRepo, BidRepo>();

//EF
//builder.Services.AddTransient<IAuctionRepo, AuctionRepo>();
//builder.Services.AddTransient<IAuctionService, AuctionService>();

//Bank DBContext
builder.Services.AddDbContext<BankAppDataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

//Identity DBContext
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer
(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

//Auth
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.SaveToken = true;
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidAudience = configuration["JWT:ValidAudience"],
            ValidIssuer = configuration["JWT:ValidIssuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]))
        };
    });

builder.Services.AddAutoMapper(typeof(Program).Assembly, typeof(Account).Assembly);
builder.Services.AddAutoMapper(typeof(Program).Assembly, typeof(Disposition).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseRouting();

app.UseHttpsRedirection(); //

app.UseAuthentication();

app.UseCors();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.UseSwagger();
app.UseSwaggerUI();

app.Run();
