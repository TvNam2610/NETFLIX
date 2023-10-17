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
    }
}
