using Microsoft.Extensions.DependencyInjection;

namespace AdvancedDatabase_Lab2.ConsoleDI
{
    public interface IExampleSingletonService : IReportServiceLifetime
    {
        ServiceLifetime IReportServiceLifetime.Lifetime => ServiceLifetime.Singleton;
    }
}

/*
    All of the subinterfaces of IReportServiceLifetime explicitly implement 
    the IReportServiceLifetime.Lifetime with a default. For example, 
    IExampleTransientService explicitly implements IReportServiceLifetime.Lifetime
    with the ServiceLifetime.Transient value.
*/