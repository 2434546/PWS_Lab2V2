namespace ForumDeDiscussion.Models
{
    public class Section
    {
        int Id { get; set; }
        string Titre { get; set; }
        List<Sujet> Sujets { get; set; }

    }
}
