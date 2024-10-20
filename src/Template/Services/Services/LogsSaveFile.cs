using Template.Domain.Interface;
using Template.Domain.LogsAggregate.Enum;

namespace Template.Services.Services
{
    public class LogsSaveFile : ILogServices
    {
        public LogsType UseLogsType => LogsType.SaveFile;

        private readonly string logFilePath;

        // Constructor que configura la ruta del archivo por defecto
        public LogsSaveFile()
        {
            // Ruta del directorio del proyecto (donde se ejecuta el binario)
            string projectDirectory = AppDomain.CurrentDomain.BaseDirectory;

            // Ir cuatro carpetas hacia atrás
#pragma warning disable CS8602 // Desreferencia de una referencia posiblemente NULL.
            string targetDirectory = Directory.GetParent(projectDirectory).Parent.Parent.Parent.FullName;
#pragma warning restore CS8602 // Desreferencia de una referencia posiblemente NULL.


            // Combinar la ruta con el nombre del archivo de log por defecto
            logFilePath = Path.Combine(targetDirectory, "dataLogs.txt");
        }

        public async Task<bool> SaveLogsService(string title, string messageLogs, CancellationToken cancellationToken = default)
        {
            try
            {
                await using StreamWriter writer = new StreamWriter(logFilePath, true);
                writer.WriteLine(title.ToString() + "-" + messageLogs);
                writer.WriteLine(new string('-', 50)); // Separador de entradas
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing to log file: {ex.Message}");
                return false;
            }
        }
    }
}
