using System.ComponentModel.DataAnnotations;

namespace ForumDeDiscussion.Models
{
    public class Section
    {
        public int Id { get; set; }

        [Display(Name = "Nom de la section")]
        public string Titre { get; set; } = String.Empty;
        public List<Sujet> Sujets { get; set; }

    }
}
