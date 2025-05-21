using System.ComponentModel.DataAnnotations;

namespace MVC_DB.Models
{
    public class NobelWinners
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Vorname { get; set; }
        [Required]
        public string Nachname { get; set; }
        public string Geburtsort { get; set; }
        public string Geburtsdatum { get; set; }
        public string Geburtsland { get; set; }

    }
}
