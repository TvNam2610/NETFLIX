using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IWatchHistoryRepository
    {
        List<WatchHistoryModel> GetDataByUser(string username);
        List<WatchHistoryModel> ThongKe(int pageIndex, int pageSize,out long total, string ten_nguoi_xem, DateTime? frNgayXem,DateTime? toNgayXem );
    }
}
