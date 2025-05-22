using System.ComponentModel.DataAnnotations;

namespace MVC_DB.Models
{
    public class Rating
    {
        [Key]
        public int Id { get; set; }
        public double Rate { get; set; }
        public int Count { get; set; }
    }
}