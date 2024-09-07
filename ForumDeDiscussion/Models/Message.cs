using System.ComponentModel.DataAnnotations;

namespace ForumDeDiscussion.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string Titre { get; set; }
        public string Contenu { get; set; }
        public int MembreId { get; set; }
        public Membre Membre { get; set; }
        public int SujetId { get; set; }
        public Sujet Sujet { get; set; }
    }
}
