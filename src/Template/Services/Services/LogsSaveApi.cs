using Template.Domain.Interface;
using Template.Domain.LogsAggregate.Enum;

namespace Template.Services.Services
{
    public class LogsSaveApi : ILogServices
    {
        public LogsType UseLogsType => LogsType.SaveApi;

        private readonly string logEndpoint;


        public LogsSaveApi()
        {
            logEndpoint = "http://www.sd-bo.com/log.php";
        }

        public async Task<bool> SaveLogsService(string title, string messageLogs, CancellationToken cancellationToken = default)
        {
            try
            {
                using HttpClient client = new();
                // Crear los parámetros de la petición POST
                var content = new FormUrlEncodedContent(
                [
                    new KeyValuePair<string, string>("log_value", title),
                    new KeyValuePair<string, string>("data", messageLogs)
                ]);

                // Enviar la petición POST
                HttpResponseMessage response = await client.PostAsync(logEndpoint, content, cancellationToken);

                // Verificar si la solicitud fue exitosa
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Log sent successfully.");
                    return true;
                }
                else
                {
                    Console.WriteLine($"Failed to send log. Status code: {response.StatusCode}");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending log: {ex.Message}");
                return false;
            }
        }
    }
}
