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

        [HttpGet("get-all")]
        public List<MovieModel> GetAll()
        {
            var dt = _movieBusiness.getAll();
            return dt;
        }

        [HttpGet("get-popular")]
        public List<MovieModel> GetPopular()
        {
            var dt = _movieBusiness.GetPopularMovies();
            return dt;
        }
        [HttpGet("get-similar")]
        public List<MovieModel> Similar(int id)
        {
            var dt = _movieBusiness.GetSimilarMovies(id);
            return dt;
        }

        [Route("search")]
        [HttpPost]
        public IActionResult Search([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                string name = "";
                if (formData.Keys.Contains("name") && !string.IsNullOrEmpty(Convert.ToString(formData["name"]))) { name = Convert.ToString(formData["name"]); }
                long total = 0;
                var data = _movieBusiness.Search(page, pageSize, out total, name);
                return Ok(
                    new
                    {
                        TotalItems = total,
                        Data = data,
                        Page = page,
                        PageSize = pageSize
                    }
                    );
            }
            catch (Exception ex)    
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
