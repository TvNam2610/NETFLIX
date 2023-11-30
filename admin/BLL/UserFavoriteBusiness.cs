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

        public bool Create(UserFavoriteModel model)
        {
            return _res.Create(model);
        }

        public bool Delete(int userid, int movieid)
        {
            return _res.Delete(userid, movieid);
        }
    }
}
