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
        private IGenreBusiness _genreBusiness;
        public GenreController(IGenreBusiness genreBusiness)
        {
            _genreBusiness = genreBusiness;
        }

        [HttpGet("get-all")]
        public IActionResult GetAll()
        {
            var dt = _genreBusiness.GetAll().Select(x => new { x.GenreID,x.Name});
            return Ok(dt);  
        }


        [HttpGet("get-by-id")]
        public GenreModel GetDataById(int id)
        {
            var dt = _genreBusiness.GetbyID(id);
            return dt;
        }

        [Route("create-genre")]
        [HttpPost]
        public GenreModel CreateItem([FromBody] GenreModel model)
        {
            _genreBusiness.Create(model);
            return model;
        }

        [Route("update-movie")]
        [HttpPost]
        public GenreModel UpdateItem([FromBody] GenreModel model)
        {
            _genreBusiness.Update(model);
            return model;
        }

        [Route("delete-movie")]
        [HttpDelete]
        public IActionResult DeleteItem(int id)
        {
            _genreBusiness.Delete(id);
            return Ok(new { message = "xoas thanh cong" });
        }
    }
}
