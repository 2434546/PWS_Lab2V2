namespace ForumDeDiscussion.Models
{
    public class Membre
    {
        Guid Id { get; set; }
        string Name { get; set; } = "";
        string Firstname { get; set; } = "";
        string Mail { get; set; } = "";
        string Password { get; set; } = "";
        string UserName { get; set; } = ""; 
        List<Message> Messages { get; set; } = new List<Message>();
    }
}
