using BLL;
using BLL.Interfaces;
using DataModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserFavoriteController : ControllerBase
    {
        private IUserFavoriteBusiness _wBusiness;
        public UserFavoriteController(IUserFavoriteBusiness wBusiness)
        {
            _wBusiness = wBusiness;
        }

        [Route("add-favorite")]
        [HttpPost]
        public UserFavoriteModel CreateItem([FromBody] UserFavoriteModel model)
        {
            _wBusiness.Create(model);
            return model;
        }

        [Route("delete-favorite")]
        [HttpDelete]
        public IActionResult DeleteItem(int userid, int movieid)
        {
            _wBusiness.Delete(userid, movieid);
            return Ok(new { message = "xoas thanh cong" });
        }
    }
}
