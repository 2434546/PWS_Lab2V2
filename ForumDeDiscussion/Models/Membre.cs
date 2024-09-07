namespace ForumDeDiscussion.Models
{
    public class Membre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Firstname { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public List<Message> Messages { get; set; }
    }
}
