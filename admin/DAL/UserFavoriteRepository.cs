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
    public class UserFavoriteRepository : IUserFavoriteRepository
    {
        private IDatabaseHelper _db;

        public UserFavoriteRepository(IDatabaseHelper db)
        {
            _db = db;
        }
        public List<UserFavoriteModel> GetDataByUser(string username)
        {
            string msgError = "";
            try
            {
                var dt = _db.ExecuteSProcedureReturnDataTable(out msgError, "GetUserFavoriteByUsername",
                     "@username", username);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<UserFavoriteModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
