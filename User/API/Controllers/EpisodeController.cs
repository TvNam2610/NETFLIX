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

        [Route("update-episode")]
        [HttpPost]
        public EpisodeModel UpdateItem([FromBody] EpisodeModel model)
        {
            _episodeBusiness.Update(model);
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
                string ten_phim = "";
                if (formData.Keys.Contains("ten_phim") && !string.IsNullOrEmpty(Convert.ToString(formData["ten_phim"]))) { ten_phim = Convert.ToString(formData["ten_phim"]); }
                string the_loai = "";
                if (formData.Keys.Contains("the_loai") && !string.IsNullOrEmpty(Convert.ToString(formData["the_loai"]))) { the_loai = Convert.ToString(formData["the_loai"]); }
                long total = 0;
                var data = _episodeBusiness.Search(page, pageSize, out total, ten_phim, the_loai);
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
