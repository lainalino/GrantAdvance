using Microsoft.OpenApi.Models;

namespace GrantAdvance.API.Extensions
{
    public static class MiddlewareExtensions
    {
        public static IServiceCollection AddCustomSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(cfg =>
            {
                cfg.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Grant Advance - Laina Lino",
                    Version = "v4",
                    Description = "Example API that shows how to implement JSON Web Token authentication and authorization with ASP.NET Core 7, built from scratch.",
                    Contact = new OpenApiContact
                    {
                        Name = "Laina Lino",
                        Url = new Uri("https://www.linkedin.com/in/lainalino")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "MIT",
                    },
                });

                cfg.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "JSON Web Token to access resources. Example: Bearer {token}",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });

                cfg.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
                    },
                    new [] { string.Empty }
                }
            });
            });

            return services;
        }

        public static IApplicationBuilder UseCustomSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger().UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Grant Advance - Laina Lino");
                options.DocumentTitle = "Grant Advance - Laina Lino";
            });

            return app;
        }
    }

}
