using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUserRepository
    {
        UserModel Login(string username, string password);
        List<UserModel> GetAll();
        UserModel GetDataById(string id);
        bool Create(UserModel model);
        bool Update(UserModel model);
        bool Delete(string id);

    }
}
