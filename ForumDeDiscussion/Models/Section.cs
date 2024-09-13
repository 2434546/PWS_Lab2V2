namespace ForumDeDiscussion.Models
{
    public class Section
    {
        public int Id { get; set; }
        public string Titre { get; set; } = String.Empty;
        public List<Sujet> Sujets { get; set; }

    }
}
