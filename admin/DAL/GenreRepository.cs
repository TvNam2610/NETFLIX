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
    public class GenreRepository : IGenreRepository
    {
        private IDatabaseHelper _db;
        public GenreRepository(IDatabaseHelper db)
        {
            _db = db;
        }


        public List<GenreModel> GetAll()
        {
            try
            {
                var data = _db.ExecuteQuery("sp_get_all_genre");

                return data.ConvertTo<GenreModel>().ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public GenreModel GetbyID(int id)
        {
            string msgError = "";
            try
            {
                var dt = _db.ExecuteSProcedureReturnDataTable(out msgError, "sp_get_genre_ID",
                     "@genreID", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<GenreModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Create(GenreModel model)
        {
            string msgError = "";
            try
            {
                var result = _db.ExecuteScalarSProcedureWithTransaction(
                    out msgError,
                    "sp_genre_create", "@name", model.Name);


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

        public bool Delete(int id)
        {
            string msgError = "";
            try
            {
                var result = _db.ExecuteScalarSProcedureWithTransaction(
                    out msgError,
                    "sp_genre_delete", "@genreID", id);

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


        public bool Update(GenreModel model)
        {
            string msgError = "";
            try
            {
                var result = _db.ExecuteScalarSProcedureWithTransaction(
                    out msgError,
                    "sp_genre_update",
                "@genreID", model.GenreID,
                "@name", model.Name);

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
