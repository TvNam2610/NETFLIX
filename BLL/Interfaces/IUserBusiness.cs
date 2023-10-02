using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IUserBusiness
    {
        List<UserModel> GetAll();

        UserModel Login(string username, string password);
        UserModel GetDataById(string id);

        bool Create(UserModel model);

        bool Update(UserModel model);

        bool Delete(string id);
    }
}
