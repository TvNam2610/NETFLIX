using BLL;
using BLL.Interfaces;
using DataModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EpisodeController : ControllerBase
    {
        private IEpisodeBusiness _episodeBusiness;
        public EpisodeController(IEpisodeBusiness episodeBusiness)
        {
            _episodeBusiness = episodeBusiness;
        }

        [HttpGet("get-by-id")]
        public EpisodeModel GetDataById(int id)
        {
            var dt = _episodeBusiness.GetbyID(id);
            return dt;
        }

        [Route("create-episode")]
        [HttpPost]
        public EpisodeModel CreateItem([FromBody] EpisodeModel model)
        {
            _episodeBusiness.Create(model);
            return model;
        }

        [Route("Add-movie-for-Episode")]
        [HttpPost]
        public AddMovieRequestDto AddMovie([FromBody] AddMovieRequestDto model)
        {
            _episodeBusiness.AddMovieForEpisode(model);
            return model;
        }

        [Route("update-episode")]
        [HttpPost]
        public EpisodeModel UpdateItem([FromBody] EpisodeModel model)
        {
            _episodeBusiness.Update(model);
            return model;
        }

        [Route("update-movie-for-Episode")]
        [HttpPost]
        public MovieDto UpdateMovie([FromBody] MovieDto model)
        {
            _episodeBusiness.UpdateMovieForEpisode(model);
            return model;
        }

        [Route("delete-episode")]
        [HttpDelete]
        public IActionResult DeleteItem(int id)
        {
            _episodeBusiness.Delete(id);
            return Ok(new { message = "xoas thanh cong" });
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
                var data = _episodeBusiness.Search(page, pageSize, out total, name);
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
