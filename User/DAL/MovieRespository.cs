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

        public bool Create(MovieModel model)
        {
            string msgError = "";
            try
            {
                var result = _db.ExecuteScalarSProcedureWithTransaction(
                    out msgError,
                    "sp_movie_create",
                "@title", model.Title,
                "@releaseDate", model.ReleaseDate,
                "@description", model.Description,
                "@coverImageURL", model.CoverImageURL,
                "@videoURL", model.VideoURL,
                "@duration", model.Duration,
                "@ageRecommend", model.AgeRecommend,
                "@genre", model.Genre,
                "@list_json_MovieActors", model.list_json_MovieActors != null ? MessageConvert.SerializeObject(model.list_json_MovieActors) : null,
                "@list_json_MovieDirectors", model.list_json_MovieDirectors != null ? MessageConvert.SerializeObject(model.@list_json_MovieDirectors) : null);
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
