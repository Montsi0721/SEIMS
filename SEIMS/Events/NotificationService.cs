using SEIMS.Collections;
using SEIMS.Models;

namespace SEIMS.Events
{
    /// <summary>
    /// Separate notification class (Question 4). Subscribes to OnStockThresholdCritical,
    /// logs through a LogHandler delegate and shows an alert on screen.
    /// </summary>
    public class NotificationService : IDisposable
    {
        private readonly ItemWarehouse _warehouse;
        private readonly LogHandler _log;
        private readonly Action<string> _showAlert;

        public NotificationService(ItemWarehouse warehouse, LogHandler log, Action<string> showAlert)
        {
            _warehouse = warehouse;
            _log = log;
            _showAlert = showAlert;
            _warehouse.OnStockThresholdCritical += HandleCritical;
        }

        private void HandleCritical(InventoryItem item, int quantity)
        {
            string message = "CRITICAL STOCK: " + item.Sku + " (" + item.Name + ") has only " + quantity + " unit(s) left.";
            if (_log != null) _log(message);
            if (_showAlert != null) _showAlert(message);
        }

        public void Dispose()
        {
            _warehouse.OnStockThresholdCritical -= HandleCritical;
        }
    }
}
