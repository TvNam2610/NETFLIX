using BLL.Interfaces;
using DataModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private IMovieBusiness _movieBusiness;
        public MovieController(IMovieBusiness movieBusiness)
        {
            _movieBusiness = movieBusiness;
        }

        [HttpGet("get-by-id")]
        public MovieModel GetDataById(int id)
        {
            var dt = _movieBusiness.getbyID(id);
            return dt;
        }
    }
}
