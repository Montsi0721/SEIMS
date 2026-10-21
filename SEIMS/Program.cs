using Microsoft.Data.SqlClient;
using SEIMS.Data;
using SEIMS.Services;
using SEIMS.UI;

namespace SEIMS
{
    internal static class Program
    {
        [STAThread]
        private static void Main(string[] args)
        {
            if (args.Any(a => string.Equals(a, "--demo", StringComparison.OrdinalIgnoreCase)))
            {
                ConsoleDemo.Run();
                return;
            }

            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.SetHighDpiMode(HighDpiMode.SystemAware);

            FileLogger logger = new FileLogger(AppConfig.LogFilePath);
            logger.Write("=== SEIMS started ===");

            Application.ThreadException += (s, e) =>
            {
                logger.Write("UNHANDLED ERROR: " + e.Exception);
                MessageBox.Show("Something went wrong:\n\n" + e.Exception.Message,
                    "SEIMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            };

            try
            {
                DatabaseInitializer.Initialize(logger);
            }
            catch (SqlException ex)
            {
                logger.Write("DATABASE ERROR: " + ex.Message);
                MessageBox.Show(
                    "SEIMS could not reach SQL Server.\n\n" + ex.Message +
                    "\n\nCheck the ConnectionString in appsettings.json and that SQL Server LocalDB is installed.",
                    "SEIMS - database", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (Exception ex)
            {
                logger.Write("STARTUP ERROR: " + ex);
                MessageBox.Show("SEIMS could not start:\n\n" + ex.Message, "SEIMS",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool again = true;
            while (again)
            {
                again = false;

                using (LoginForm login = new LoginForm())
                {
                    if (login.ShowDialog() != DialogResult.OK) break;
                }

                logger.Write("LOGIN " + SecurityService.CurrentUsername + " (" + SecurityService.CurrentRole + ")");

                using (InventoryService service = new InventoryService(logger))
                {
                    service.Initialize();
                    using (MainForm main = new MainForm(service, logger))
                    {
                        Application.Run(main);
                        again = main.LogoutRequested;
                    }
                }

                logger.Write("LOGOUT " + SecurityService.CurrentUsername);
                SecurityService.Logout();
            }

            logger.Write("=== SEIMS closed ===");
        }
    }
}
