using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ProjectAD_MauroArys.Data;
using ProjectAD_MauroArys.Services;
using System.Text;

namespace ProjectAD_MauroArys
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlite("Data Source=meetingrooms.db");
                options.LogTo(Console.WriteLine, LogLevel.Information);
            });

            builder.Services.AddScoped<IRoomRepository, RoomRepository>();
            builder.Services.AddScoped<IRoomService, RoomService>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IAuthService, AuthService>();

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = builder.Configuration["Jwt:Issuer"],
                        ValidAudience = builder.Configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
                    };
                });


            builder.Services.AddControllers();
            builder.Services.AddProblemDetails();

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                DbInitializer.Seed(context);
            }

            app.UseExceptionHandler();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();

        }
    }
}
