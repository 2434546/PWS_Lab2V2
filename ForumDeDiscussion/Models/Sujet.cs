namespace ForumDeDiscussion.Models
{
    public class Sujet
    {
        int Id { get; set; }
        string Titre { get; set; }
        int SectionId { get; set; }
        Section Section { get; set; }
        List<Message> Messages { get; set; }
    }
}
