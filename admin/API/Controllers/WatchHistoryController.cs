using BLL;
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
            var dt = _wBusiness.GetDataByUser(username).Select(x => new {x.HistoryID,x.Title,x.WatchDate});
            return Ok(dt);
        }

        [HttpPost("Thong-ke-lich-su-xem")]
        public IActionResult Thong_ke([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());

                string ten_nguoi_xem = "";
                if (formData.Keys.Contains("ten_nguoi_xem") && !string.IsNullOrEmpty(Convert.ToString(formData["ten_nguoi_xem"])))
                {
                    ten_nguoi_xem = Convert.ToString(formData["ten_nguoi_xem"]);
                }

                DateTime? frNgayXem = null; 
                if (formData.Keys.Contains("frNgayXem") && formData["frNgayXem"] != null &&
                    formData["frNgayXem"].ToString()!= "")
                {
                    var dt  = Convert.ToDateTime(formData["frNgayXem"].ToString());
                    frNgayXem = new DateTime(dt.Year, dt.Month, dt.Day, 0, 0, 0, 0);
                }

                DateTime? toNgayXem = null;
                if (formData.Keys.Contains("toNgayXem") && formData["toNgayXem"] != null &&
                    formData["toNgayXem"].ToString() != "")
                {
                    var dt = Convert.ToDateTime(formData["toNgayXem"].ToString());
                    toNgayXem = new DateTime(dt.Year, dt.Month, dt.Day, 0, 0, 0, 0);
                }
               
                long total = 0;
                var data = _wBusiness.ThongKe(page, pageSize, out total, ten_nguoi_xem,frNgayXem, toNgayXem);
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
                return BadRequest(ex.Message);
            }
        }

    }
}
