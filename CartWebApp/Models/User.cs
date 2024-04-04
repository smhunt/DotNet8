namespace CartWebApp.Models;
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; }   = string.Empty;
        public string PasswordHash { get; set; }    = string.Empty;
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        // Additional properties like FirstName, LastName, etc.
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        // For future use with roles and permissions
        public ICollection<string> Roles { get; set; } = new List<string>();
    }
