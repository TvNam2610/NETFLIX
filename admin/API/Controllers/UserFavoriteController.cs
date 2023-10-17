using BLL.Interfaces;
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

        [HttpGet("get-by-user")]
        public IActionResult GetDataByUser(string username)
        {
            var dt = _wBusiness.GetDataByUser(username).Select(x => new { x.FavoriteID, x.Title });
            return Ok(dt);
        }
    }
}
