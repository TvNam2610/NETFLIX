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
        public List<GenreDtoWithMovie> getAllWithMovie()
        {
            string msgError = "";
            try
            {
                var dt = _db.ExecuteSProcedureReturnDataTable(out msgError, "sp_get_all_genres_with_movies");

                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<GenreDtoWithMovie>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<GenreDtoWithEpisode> getAllWithEpisode()
        {
            string msgError = "";
            try
            {
                var dt = _db.ExecuteSProcedureReturnDataTable(out msgError, "sp_get_all_genres_with_episodes");

                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<GenreDtoWithEpisode>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
