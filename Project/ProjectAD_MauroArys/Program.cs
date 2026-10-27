using ProjectAD_MauroArys.Data;

namespace ProjectAD_MauroArys
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();
            builder.Services.AddProblemDetails();
            var app = builder.Build();

            using (var context = new AppDbContext())
            {

                DbInitializer.Seed(context);
            }
            app.UseExceptionHandler();
            app.MapControllers();
            app.Run();

        }
    }
}
