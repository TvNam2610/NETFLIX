using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUserFavoriteRepository
    {
        bool Create(UserFavoriteModel model);
        bool Delete(int userid,int movieid);
    }
}
