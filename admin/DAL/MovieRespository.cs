using DAL.Interfaces;
using DataAccessLayer;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MovieRespository:IMovieRespository
    {
        private IDatabaseHelper _db;
        public MovieRespository(IDatabaseHelper db)
        {
            _db = db;
        }
        public MovieModel GetbyID(int id)    
        {
            string msgError = "";
            try
            {
                var dt = _db.ExecuteSProcedureReturnDataTable(out msgError, "sp_get_movie_ID",
                     "@movieid", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<MovieModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<MovieModel> Search(int pageIndex, int pageSize, out long total, string ten_phim, string the_loai)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _db.ExecuteSProcedureReturnDataTable(out msgError, "sp_movie_search",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                    "@title ", ten_phim ,
                    "@genre", the_loai);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<MovieModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<MovieModel> GetAll()
        {
            string msgError = "";
            try
            {
                var dt = _db.ExecuteSProcedureReturnDataTable(out msgError, "sp_getAll_movies" );
                   
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<MovieModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<MovieModel> GetPopularMovies()
        {
            string msgError = "";
            try
            {
                var dt = _db.ExecuteSProcedureReturnDataTable(out msgError, "sp_get_popular_movies");

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
