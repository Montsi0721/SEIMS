using System.Security.Cryptography;
using System.Security.Principal;
using SEIMS.Data;
using SEIMS.Models;

namespace SEIMS.Services
{
    public enum Permission
    {
        View,
        Edit,
        Delete,
        Print,
        Export,
        Import
    }

    /// <summary>
    /// Role based security (Question 10): login with salted PBKDF2 hashes and per-action
    /// permission checks. Only Admin accounts may delete items.
    /// </summary>
    public static class SecurityService
    {
        private const int Iterations = 100000;

        public static AppUser CurrentUser { get; private set; }

        public static string CurrentUsername
        {
            get { return CurrentUser != null ? CurrentUser.Username : "anonymous"; }
        }

        public static UserRole CurrentRole
        {
            get { return CurrentUser != null ? CurrentUser.Role : UserRole.Viewer; }
        }

        public static bool Can(Permission permission)
        {
            if (CurrentUser == null) return false;

            switch (CurrentUser.Role)
            {
                case UserRole.Admin:
                    return true;
                case UserRole.Manager:
                    return permission != Permission.Delete;
                default:
                    return permission == Permission.View;
            }
        }

        /// <summary>Throws UnauthorizedAccessException when the signed-in role may not do this.</summary>
        public static void Demand(Permission permission)
        {
            if (!Can(permission))
                throw new UnauthorizedAccessException(
                    "Your role (" + CurrentRole + ") is not authorised to perform: " + permission + ".");
        }

        public static bool TryLogin(string username, string password, out string error)
        {
            error = null;
            username = InputSanitizer.CleanText(username, 50);

            if (username.Length == 0 || string.IsNullOrEmpty(password))
            {
                error = "Enter your username and password.";
                return false;
            }

            AppUser user;
            using (var db = new SeimsDbContext())
            {
                user = db.Users.FirstOrDefault(u => u.Username == username);
            }

            if (user == null || !user.IsActive || !Verify(password, user.Salt, user.PasswordHash))
            {
                error = "Invalid username or password.";
                return false;
            }

            CurrentUser = user;
            Thread.CurrentPrincipal = new GenericPrincipal(
                new GenericIdentity(user.Username), new[] { user.Role.ToString() });
            return true;
        }

        public static void Logout()
        {
            CurrentUser = null;
            Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(""), new string[0]);
        }

        // ---------- password hashing ----------
        public static void CreateHash(string password, out string saltBase64, out string hashBase64)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(16);
            byte[] hash = Rfc2898DeriveBytes.Pbkdf2(password, salt, Iterations, HashAlgorithmName.SHA256, 32);
            saltBase64 = Convert.ToBase64String(salt);
            hashBase64 = Convert.ToBase64String(hash);
        }

        public static bool Verify(string password, string saltBase64, string hashBase64)
        {
            try
            {
                byte[] salt = Convert.FromBase64String(saltBase64);
                byte[] expected = Convert.FromBase64String(hashBase64);
                byte[] actual = Rfc2898DeriveBytes.Pbkdf2(password, salt, Iterations, HashAlgorithmName.SHA256, expected.Length);
                return CryptographicOperations.FixedTimeEquals(actual, expected);
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}
