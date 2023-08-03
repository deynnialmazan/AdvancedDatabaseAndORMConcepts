using Microsoft.Extensions.DependencyInjection;

namespace AdvancedDatabase_Lab2.ConsoleDI
{
    public interface IReportServiceLifetime
    {
        Guid Id { get; }

        ServiceLifetime Lifetime { get; }
    }
}

/*
    The IReportServiceLifetime interface defines:
    A Guid Id property that represents the unique identifier of the service.
    A ServiceLifetime property that represents the service lifetime.
*/