using GrantAdvance.API.Extensions;
using GrantAdvance.API.Mapping;
using GrantAdvance.Data.Context;
using GrantAdvance.Infras.Repositories;
using GrantAdvance.Infras.Repositories.Interface;
using GrantAdvance.Infras.Security;
using GrantAdvance.Infras.Security.Interface;
using GrantAdvance.Infras.Services;
using GrantAdvance.Infras.Services.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCustomSwagger();
builder.Services.AddControllers();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAuthenticateService, AuthenticateService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddSingleton<IPasswordHasher, PasswordHasher>();
builder.Services.AddSingleton<ITokenHandler, TokenHandler>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddAutoMapper(typeof(ViewModelToModel));
builder.Services.AddIdentityServices(builder.Configuration);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
             providerOptions =>
             {
                 providerOptions.CommandTimeout(3800);
             });
   // options.ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning));
});

var app = builder.Build();

app.UseDeveloperExceptionPage();
app.UseRouting();
app.UseCustomSwagger();
app.UseAuthentication();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();
await app.RunAsync();
