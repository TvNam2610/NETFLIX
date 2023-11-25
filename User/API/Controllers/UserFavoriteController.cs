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

        [HttpGet("get-movie-id")]
        public List<MovieModel> GetByUser(int userId)
        {
            var dt = _wBusiness.GetFavorite(userId);
            return dt;
        }
    }
}
