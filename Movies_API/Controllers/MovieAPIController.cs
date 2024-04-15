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
        public ActionResult<IEnumerable<MovieDTO>> GetMovies()
        {
            return Ok(Cinema.movieList);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult<MovieDTO> GetMovie(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var movie = Cinema.movieList.FirstOrDefault(u => u.Id == id);


            if (movie == null)
            {
                return NotFound();
            }

            return Ok(movie);
        }
    }
}
