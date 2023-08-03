namespace AdvancedDatabase_Lab2.ConsoleDI
{
    internal sealed class ExampleSingletonService : IExampleSingletonService
    {
        Guid IReportServiceLifetime.Id { get; } = Guid.NewGuid();
    }
}

/*
    Each implementation is defined as internal sealed and implements its 
    corresponding interface. For example, ExampleSingletonService implements 
    IExampleSingletonService.
*/