namespace ForumDeDiscussion.ViewModels;

public class MessageViewModel
{
    public int MessageId { get; set; }
    public string Contenu { get; set; }
    public string Auteur { get; set; }
    public DateTime Date { get; set; }
}