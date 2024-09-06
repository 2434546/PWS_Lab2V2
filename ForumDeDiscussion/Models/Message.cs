namespace ForumDeDiscussion.Models
{
    public class Message
    {
        Guid Id { get; set; }
        string Titre { get; set; } = "";
        string Contenu { get; set; } = "";
        Guid MembreId { get; set; }
        Membre Membre { get; set; }
        int SujetId { get; set; }
        Sujet Sujet { get; set; }
    }
}
