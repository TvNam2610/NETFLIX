using BLL;
using BLL.Interfaces;
using DataModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private IGenreBusiness _genre;
        public GenreController(IGenreBusiness genre)
        {
            _genre = genre;
        }

        [HttpGet("get-all-with-movie")]
        public List<GenreDtoWithMovie> GetAllWithMovie()
        {
            var dt = _genre.getAllWithMovie();
            return dt;
        }

        [HttpGet("get-all-with-episode")]
        public List<GenreDtoWithEpisode> GetAllWithEpisode()
        {
            var dt = _genre.getAllWithEpisode();
            return dt;
        }
    }
}
