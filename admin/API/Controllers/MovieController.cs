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

        [Route("search")]
        [HttpPost]
        public IActionResult Search([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                string ten_phim = "";
                if (formData.Keys.Contains("ten_phim") && !string.IsNullOrEmpty(Convert.ToString(formData["ten_phim"]))) { ten_phim = Convert.ToString(formData["ten_phim"]); }
                string the_loai = "";
                if (formData.Keys.Contains("the_loai") && !string.IsNullOrEmpty(Convert.ToString(formData["the_loai"]))) { the_loai = Convert.ToString(formData["the_loai"]); }
                long total = 0;
                var data = _movieBusiness.Search(page, pageSize, out total, ten_phim, the_loai);
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
