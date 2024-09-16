namespace ForumDeDiscussion.Models
{
    public class Member
    {
        public const string ROLE_ADMIN = "Admin";
        public const string ROLE_MEMBER = "Membre";
        
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Firstname { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Role { get; set; } = ROLE_MEMBER;
        public List<Message> Messages { get; set; }

        public Member()
        {
        }
    }
}
