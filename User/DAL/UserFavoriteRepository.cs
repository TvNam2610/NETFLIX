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
        public List<MovieModel> GetDataByUser(int userID)
        {
            string msgError = "";
            try
            {
                var dt = _db.ExecuteSProcedureReturnDataTable(out msgError, "GetFavoriteMovies",
                     "@UserID", userID);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<MovieModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
