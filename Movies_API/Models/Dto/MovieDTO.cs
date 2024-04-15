using System.ComponentModel.DataAnnotations;

namespace Movies_API.Models.Dto
{
    public class MovieDTO
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
