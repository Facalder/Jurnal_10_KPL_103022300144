using Microsoft.AspNetCore.Mvc;
using modul10_103022300144.Models;

namespace modul10_103022300144.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : Controller
    {
        private static readonly List<Movie> _moviesList = new List<Movie>()
        {
            new Movie {
                Title = "The Shawshank Redemption",
                Director = "Frank Darabont",
                Stars = ["Tim Robbins", "Bob Gunton"],
                Description = "A banker convicted of uxoricide forms a friendship over a quarter century with " +
                "a hardened convict, while maintaining his innocence and trying to remain hopeful through simple compassion."
            },

            new Movie
            {
                Title = "The Godfather",
                Director = "Francis Ford Coppola",
                Stars = ["Marlon Brando", "James Caan"],
                Description = "The aging patriarch of an organized crime dynasty transfers control " +
                "of his clandestine empire to his reluctant son."
            },

            new Movie
            {
                Title = "The Dark Knight",
                Director = "Christoper Nolan",
                Stars = ["Christian Bale", "Gary Oldman"],
                Description = "When a menace known as the Joker wreaks havoc and chaos on the people of" +
                " Gotham, Batman, James Gordon and Harvey Dent must work together to put an end to the madness."
            },
        };

        [HttpGet]
        public ActionResult<IEnumerable<Movie>> Get()
        {
            return _moviesList;
        }

        [HttpGet("{id}")]
        public ActionResult<Movie> Get(int id)
        {
            var movie = _moviesList[id]; // berarti harus id > 0

            if (movie == null)
            {
                return NotFound();
            }

            return movie;
        }

        [HttpPost]
        public ActionResult<Movie> Post([FromBody] Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _moviesList.Add(movie);
            return CreatedAtAction(nameof(Get), new { title = movie.Title }, movie);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var movieId = _moviesList[id]; // berarti harus id > 0

            if (movieId == null)
            {
                return NotFound();
            }

            _moviesList.RemoveAt(id);
            return NoContent();
        }
    };
}

