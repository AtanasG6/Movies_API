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

        [HttpGet("{id:int}", Name = "GetMovie")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(200, Type = typeof(MovieDTO))]
        //[ProducesResponseType(200)]
        //[ProducesResponseType(400)]
        //[ProducesResponseType(404)]
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

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<MovieDTO> CreateMovie([FromBody] MovieDTO movieDTO)
        {
            //without [ApiController]
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            if (Cinema.movieList.FirstOrDefault(u=>u.Name.ToLower() == movieDTO.Name.ToLower()) != null)
            {
                ModelState.AddModelError("CustomError", "Movie already exists!");
                return BadRequest(ModelState);
            }

            if (movieDTO == null)
            {
                return BadRequest(movieDTO);
            }
            if (movieDTO.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            movieDTO.Id = Cinema.movieList.OrderByDescending(u => u.Id).FirstOrDefault().Id + 1;
            Cinema.movieList.Add(movieDTO);

            return CreatedAtRoute("GetMovie", new { id = movieDTO.Id}, movieDTO);
        }
    }
}
