using Microsoft.Extensions.DependencyInjection;

namespace AdvancedDatabase_Lab2.ConsoleDI
{
    public interface IExampleScopedService : IReportServiceLifetime
    {
        ServiceLifetime IReportServiceLifetime.Lifetime => ServiceLifetime.Scoped;
    }
}
