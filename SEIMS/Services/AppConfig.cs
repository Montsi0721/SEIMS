using System.Text.Json;

namespace SEIMS.Services
{
    public static class AppConfig
    {
        public const string DefaultConnection =
            @"Server=(localdb)\MSSQLLocalDB;Database=SeimsDb;Trusted_Connection=True;TrustServerCertificate=True";

        public const string Version = "1.0";

        public static string ConnectionString { get; private set; }
        public static string LogFilePath { get; private set; }

        static AppConfig()
        {
            ConnectionString = DefaultConnection;
            LogFilePath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "SEIMS", "Logs", "seims.log");

            try
            {
                string file = Path.Combine(AppContext.BaseDirectory, "appsettings.json");
                if (File.Exists(file))
                {
                    using (JsonDocument doc = JsonDocument.Parse(File.ReadAllText(file)))
                    {
                        JsonElement value;
                        if (doc.RootElement.TryGetProperty("ConnectionString", out value) &&
                            value.ValueKind == JsonValueKind.String)
                        {
                            ConnectionString = value.GetString();
                        }
                    }
                }
            }
            catch (Exception)
            {
                // fall back to the default connection string
            }
        }
    }
}
