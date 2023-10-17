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
    public class UserFavoriteBusiness : IUserFavoriteBusiness
    {
        private IUserFavoriteRepository _res;
        
        public UserFavoriteBusiness(IUserFavoriteRepository res)
        {
            _res = res;
        }
        public List<UserFavoriteModel> GetDataByUser(string username)
        {
            return _res.GetDataByUser(username);
        }
    }
}
