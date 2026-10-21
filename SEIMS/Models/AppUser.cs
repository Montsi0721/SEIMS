namespace SEIMS.Models
{
    public enum UserRole
    {
        Viewer = 0,
        Manager = 1,
        Admin = 2
    }

    /// <summary>Application account. Passwords are stored as salted PBKDF2 hashes, never as text.</summary>
    public class AppUser
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
        public string PasswordHash { get; set; }
        public string Salt { get; set; }
        public UserRole Role { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
