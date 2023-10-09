using BLL.Interfaces;
using DataModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class WatchHistoryController : ControllerBase
    {
        private IWatchHistoryBusiness _wBusiness;
        public WatchHistoryController(IWatchHistoryBusiness wBusiness)
        {
            _wBusiness = wBusiness;
        }
     
        [HttpGet("get-by-user")]
        public IActionResult GetDataByUser(string username)
        {
            var dt = _wBusiness.GetDataByUser(username).Select(x => new {x.HistoryID,x.MovieID,x.WatchDate});
            return Ok(dt);
        }

    }
}
