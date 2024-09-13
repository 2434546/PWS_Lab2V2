namespace ForumDeDiscussion.Models
{
    public class Membre
    {
        public const string ROLE_ADMIN = "Admin";
        public const string ROLE_STANDARD = "Standard";
        public const string ROLE_INVITE = "Invité";
        
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Firstname { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Role { get; set; } = ROLE_INVITE;
        public List<Message> Messages { get; set; }
    }
}
