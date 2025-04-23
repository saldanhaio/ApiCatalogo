using System.Collections.Concurrent;
using ApiCatalogo.Logging;

namespace APICatalogo.Logging;

public class CustomLoggerProvider : ILoggerProvider
{
    readonly CustomLoggerProviderCOnfiguration loggerConfig;

    readonly ConcurrentDictionary<string, CustomerLogger> loggers =
               new ConcurrentDictionary<string, CustomerLogger>();

    public CustomLoggerProvider(CustomLoggerProviderCOnfiguration config)
    {
        loggerConfig = config;
    }
    public ILogger CreateLogger(string categoryName)
    {
        return loggers.GetOrAdd(categoryName, name => new CustomerLogger(name, loggerConfig));
    }
    public void Dispose()
    {
        loggers.Clear();
    }
}