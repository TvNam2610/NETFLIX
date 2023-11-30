using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IUserFavoriteBusiness
    {
        bool Create(UserFavoriteModel model);
        bool Delete(int userid, int movieid);
    }
}
