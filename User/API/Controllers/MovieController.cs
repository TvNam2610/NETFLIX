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

        [Route("create-movie")]
        [HttpPost]
        public MovieModel CreateItem([FromBody] MovieModel model)
        {
            _movieBusiness.Create(model);
            return model;
        }

        [Route("update-movie")]
        [HttpPost]
        public MovieModel UpdateItem([FromBody] MovieModel model)
        {
            _movieBusiness.Update(model);
            return model;
        }

        [Route("delete-movie")]
        [HttpDelete]
        public IActionResult DeleteItem(int id)
        {
            _movieBusiness.Delete(id);
            return Ok(new { message = "xoas thanh cong" });
        }
    }
}
