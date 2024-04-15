using Movies_API.Models.Dto;

namespace Movies_API.Data
{
    public static class Cinema
    {
        public static List<MovieDTO> movieList = new List<MovieDTO>() {
                new MovieDTO() { Id = 1, Name = "Lord of the Rings", Description = "A fantasy epic trilogy following Frodo Baggins' quest to destroy a powerful ring and save Middle-earth." },
                new MovieDTO() { Id = 2, Name = "Jaws", Description = "A suspenseful thriller depicting a coastal town's battle against a man-eating shark terrorizing its waters." },
            };
    }
}
