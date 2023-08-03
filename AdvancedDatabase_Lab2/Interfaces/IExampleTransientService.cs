using Microsoft.Extensions.DependencyInjection;

namespace AdvancedDatabase_Lab2.ConsoleDI
{
    public interface IExampleTransientService : IReportServiceLifetime
    {
        ServiceLifetime IReportServiceLifetime.Lifetime => ServiceLifetime.Transient;
    }
}
