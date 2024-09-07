namespace ForumDeDiscussion.Models
{
    public class Sujet
    {
        public int Id { get; set; }
        public string Titre { get; set; }
        public int SectionId { get; set; }
        public Section Section { get; set; }
        public List<Message> Messages { get; set; }
    }
}
