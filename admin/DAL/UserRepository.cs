using DAL.Interfaces;
using DataAccessLayer;
using DataModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UserRepository : IUserRepository
    {
        private IDatabaseHelper _db;

        public UserRepository(IDatabaseHelper db)
        {
            _db = db;
        }

        public UserModel Login(string username, string password)
        {
            string msgError = "";
            try
            {
                var data = _db.ExecuteSProcedureReturnDataTable(
                    out msgError,
                    "sp_login",
                    "@username", username,
                    "@password", password);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return data.ConvertTo<UserModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<UserModel> GetAll()
        {
            string msgError = "";
            try
            {
                var data = _db.ExecuteQuery("sp_get_user");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return data.ConvertTo<UserModel>().ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

       

        public bool Create(UserModel model)
        {
            string msgError = "";
            try
            {
                var result = _db.ExecuteScalarSProcedureWithTransaction(
                    out msgError,
                    "sp_user_create",
                "@userName", model.Username,
                "@password", model.Password,
                "@email", model.Email,
                "@userTypeId", model.UserType);
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(UserModel model)
        {
            string msgError = "";
            try
            {
                var result = _db.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_user_update",
                "@id", model.UserID,
                "@userName", model.Username,
                "@password", model.Password,
                "@email", model.Email,
                "@userTypeId", model.UserType);
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Delete(string id)
        {
            string msgError = "";
            try
            {
                var result = _db.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_user_delete",
                "@id", id);
;
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
