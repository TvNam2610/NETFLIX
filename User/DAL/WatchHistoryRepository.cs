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
    }
}
