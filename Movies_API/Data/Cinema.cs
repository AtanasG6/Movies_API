using Movies_API.Models.Dto;

namespace Movies_API.Data
{
    public static class Cinema
    {
        public static List<MovieDTO> movieList = new List<MovieDTO>() {
                new MovieDTO() { Id = 1, Name = "Lord of the Rings" },
                new MovieDTO() { Id = 2, Name = "Jaws" },
            };
    }
}
