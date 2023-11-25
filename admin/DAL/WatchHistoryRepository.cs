using DAL.Interfaces;
using DataAccessLayer;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class WatchHistoryRepository : IWatchHistoryRepository
    {
        private IDatabaseHelper _db;

        public WatchHistoryRepository(IDatabaseHelper db)
        {
            _db = db;
        }
        public List<WatchHistoryModel> GetDataByUser(string username)
        {
            string msgError = "";
            try
            {
                var dt = _db.ExecuteSProcedureReturnDataTable(out msgError, "GetWatchHistoryByUsername",
                     "@username", username);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<WatchHistoryModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<WatchHistoryModel> ThongKe(int pageIndex, int pageSize, out long total, string ten_nguoi_xem, DateTime? frNgayXem, DateTime? toNgayXem)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _db.ExecuteSProcedureReturnDataTable(out msgError, "sp_thong_ke_xem_phim",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                    "@ten_nguoi_xem",ten_nguoi_xem,
                    "@fr_NgayXem",frNgayXem,
                    "@to_NgayXem",toNgayXem);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<WatchHistoryModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
