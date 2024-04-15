using Microsoft.AspNetCore.Mvc;
using Movies_API.Data;
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
            return Cinema.movieList;
        }

        [HttpGet("id")]
        public MovieDTO GetMovie(int id)
        {
            return Cinema.movieList.FirstOrDefault(u => u.Id == id);
        }
    }
}
