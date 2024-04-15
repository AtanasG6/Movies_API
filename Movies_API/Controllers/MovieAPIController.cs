using Microsoft.AspNetCore.Mvc;
using Movies_API.Models;
using Movies_API.Models.Dto;

namespace Movies_API.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/MovieAPI")]
    [ApiController]
    public class MovieAPIController : Controller
    {
        [HttpGet]
        public IEnumerable<MovieDTO> GetMovies()
        {
            return new List<MovieDTO>() { 
                new MovieDTO() { Id = 1, Name = "Lord of the Rings" },
                new MovieDTO() { Id = 2, Name = "Jaws" },
                
            };
        }
    }
}
