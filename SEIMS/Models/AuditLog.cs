namespace SEIMS.Models
{
    /// <summary>One row of the audit trail ("Audit Logs" on the dashboard).</summary>
    public class AuditLog
    {
        public int Id { get; set; }
        public DateTime Timestamp { get; set; }
        public string Username { get; set; }
        public string Action { get; set; }
        public string EntityName { get; set; }
        public string EntityKey { get; set; }
        public string Details { get; set; }
    }
}
