using BLL.Interfaces;
using DAL;
using DAL.Interfaces;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class WatchHistoryBusiness : IWatchHistoryBusiness
    {
        private IWatchHistoryRepository _res;
        public WatchHistoryBusiness(IWatchHistoryRepository res)
        {
            _res = res;
        }
        public List<WatchHistoryModel> GetDataByUser(string username)
        {
            return _res.GetDataByUser(username);
        }
        public List<WatchHistoryModel> ThongKe(int pageIndex, int pageSize, out long total, string ten_nguoi_xem, DateTime? frNgayXem, DateTime? toNgayXem)
        {
            return _res.ThongKe(pageIndex, pageSize, out total, ten_nguoi_xem, frNgayXem, toNgayXem);
        }

    }
}
