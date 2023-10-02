using BLL.Interfaces;
using DataModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserBusiness _accBusiness;
        public UserController(IUserBusiness accBusiness)
        {
            _accBusiness = accBusiness;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody] AuthenticateModel model)
        {
            var user = _accBusiness.Login(model.Username, model.Password);
            if (user == null) return BadRequest(new { message = "Tài khoản hoặc mật khẩu không đúng!" });
            return Ok(new { taikhoan = user.Username, Email = user.Email, token = user.token });
        }


        [HttpGet("get-all")]
        public IActionResult GetAll()
        {
            var dt = _accBusiness.GetAll().Select(x => new { x.UserID, x.Username ,x.Password });
            return Ok(dt);
        }


        [HttpGet("get-by-id")]
        public UserModel GetDataById( string id )
        {
            var dt = _accBusiness.GetDataById(id);
            return dt;
        }


        [AllowAnonymous]
        [HttpPost("create-user")]
        public UserModel CreateItem([FromBody] UserModel model)
        {
            _accBusiness.Create(model);
            return model;
        }

        [HttpPut("update-user")]
        public UserModel UpdateItem([FromBody] UserModel model)
        {
            _accBusiness.Update(model);
            return model;
        }


        [HttpDelete("delete-user")]
        public IActionResult DeleteItem(string id)
        {
            _accBusiness.Delete(id);
            return Ok(new { message = "xoas thanh cong" });
        }

    }
}
