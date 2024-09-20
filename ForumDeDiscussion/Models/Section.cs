using System.ComponentModel.DataAnnotations;

namespace ForumDeDiscussion.Models
{
    public class Section
    {
        public int Id { get; set; }

        [Display(Name = "Nom de la section")]
        public string Title { get; set; } = string.Empty;

        public List<Subject> Subjects { get; set; } = new List<Subject>();

        public Section()
        {
        }
    }
}
