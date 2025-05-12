using ApiCatalogo.Logging;

namespace APICatalogo.Logging;

public class CustomerLogger : ILogger
{
    readonly string loggerName;
    readonly CustomLoggerProviderCOnfiguration loggerConfig;

    public CustomerLogger(string name, CustomLoggerProviderCOnfiguration config)
    {
        loggerName = name;
        loggerConfig = config;
    }

    public IDisposable BeginScope<TState>(TState state)
    {
        
        return null;
    }

    public bool IsEnabled(LogLevel logLevel)
    {
        return logLevel == loggerConfig.LogLevel;
    }

    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state,
            Exception exception, Func<TState, Exception, string> formatter)
    {
        string mensagem = $"{logLevel.ToString()}: {eventId.Id} - {formatter(state, exception)}";

        EscreverTextoNoArquivo(mensagem);
    }
    

    private void EscreverTextoNoArquivo(string mensagem)
    {
        string caminhoArquivoLog = @"/home/samuel/Documentos/log/dados/Samuel_Log.txt";
        using (StreamWriter streamWriter = new StreamWriter(caminhoArquivoLog, true))
        {
            try
            {
                streamWriter.WriteLine(mensagem);
                streamWriter.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}