using WebApi.Database.Seeders;
using WebApi.Database;
using Microsoft.Extensions.Logging;

namespace WebApi.Extensions;

public static class DatabaseSeederExtension
{
    public static async Task SeedDatabase(this IHost app)
    {
        using var scope = app.Services.CreateScope();
        var services = scope.ServiceProvider;

        var logger = services.GetRequiredService<ILogger<IHost>>();
        var context = services.GetRequiredService<ApplicationDbContext>();

        var seeders = new List<ISeeder>
        {
            new AddressSeeder(context),
            new UserSeeder(context),
            new AdministratorSeeder(context),
            new SpecializationSeeder(context),
            new DoctorSeeder(context),
            new MedicalCenterSeeder(context),
            new MedicalExamSeeder(context),
            new DoctorMedicalCenterSeeder(context),
            new AppointmentSeeder(context),
        };

        foreach (var seeder in seeders)
        {
            try
            {
                logger.LogInformation("Iniciando seed de {SeederName}", seeder.GetType().Name);
                await seeder.Seed();
                logger.LogInformation("Seed de {SeederName} concluído com sucesso", seeder.GetType().Name);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "❌ Falha ao executar seed de {SeederName}", seeder.GetType().Name);
                throw;
            }
        }
    }
}