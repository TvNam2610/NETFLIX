using DAL.Interfaces;
using DataAccessLayer;
using DataModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class EpisodeRepository : IEpisodeRepository
    {
        private IDatabaseHelper _db;
        public EpisodeRepository(IDatabaseHelper db)
        {
            _db = db;
        }

        public EpisodeModel GetbyID(int id)
        {
            string msgError = "";
            try
            {
                var dt = _db.ExecuteSProcedureReturnDataTable(out msgError, "sp_get_episode_ID",
                     "@episodeid", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<EpisodeModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Create(EpisodeModel model)  
        {
            string msgError = "";
            try
            {
                var result = _db.ExecuteScalarSProcedureWithTransaction(
                    out msgError,
                    "sp_create_episode",
                "@title", model.Title,
                "@description", model.Description,
                "@seasonNumber", model.SeasonNumber,
                "@episodeNumber", model.EpisodeNumber,
                "@releaseDate", model.ReleaseDate,
                "@coverImageURL", model.CoverImageURL,
                "@movieNameURL", model.MovieNameURL,
                "@trailerURL", model.TrailerURL,
                "@ageRecommend", model.AgeRecommend,
                "@genre", model.Genre,
                "@list_json_EpisodeActors", model.list_json_EpisodeActors != null ? MessageConvert.SerializeObject(model.list_json_EpisodeActors) : null,
                "@list_json_EpisodeDirectors", model.list_json_EpisodeDirectors != null ? MessageConvert.SerializeObject(model.list_json_EpisodeDirectors) : null);

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
                    "sp_episode_delete", "@episodeID", id);

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


        public List<EpisodeModel> Search(int pageIndex, int pageSize, out long total, string name)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _db.ExecuteSProcedureReturnDataTable(out msgError, "sp_episode_search",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                    "@name", name);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<EpisodeModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(EpisodeModel model)
        {
            string msgError = "";
            try
            {
                var result = _db.ExecuteScalarSProcedureWithTransaction(
                    out msgError,
                    "sp_update_episode",
                    "@episodeID", model.EpisodeID,
                    "@title", model.Title,
                    "@description", model.Description,
                    "@seasonNumber", model.SeasonNumber,
                    "@episodeNumber", model.EpisodeNumber,
                    "@releaseDate", model.ReleaseDate,
                    "@coverImageURL", model.CoverImageURL,
                    "@movieNameURL", model.MovieNameURL,
                    "@trailerURL", model.TrailerURL,
                    "@ageRecommend", model.AgeRecommend,
                    "@genre", model.Genre,
                    "@list_json_EpisodeActors", model.list_json_EpisodeActors != null ? MessageConvert.SerializeObject(model.list_json_EpisodeActors) : null,
                    "@list_json_EpisodeDirectors", model.list_json_EpisodeDirectors != null ? MessageConvert.SerializeObject(model.list_json_EpisodeDirectors) : null);

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

        public bool AddMovieForEpisode(AddMovieRequestDto model)
        {
            string msgError = "";
            var jsonMovies = JsonConvert.SerializeObject(model.list_json_Movies);
            try
            {
                var result = _db.ExecuteScalarSProcedureWithTransaction(
                    out msgError,
                    "sp_add_movies_to_episode",
                "@episodeID", model.EpisodeID,
                "@list_json_Movies", jsonMovies);
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

        public bool UpdateMovieForEpisode(MovieDto model)
        {
            string msgError = "";
            try
            {
                var result = _db.ExecuteScalarSProcedureWithTransaction(
                    out msgError,
                    "update_movies_for_episode",
                    "@movieID", model.MovieID,
                    "@Title", model.Title,
                    "@releaseDate", model.ReleaseDate,
                    "@Description", model.Description,
                    "@coverImageURL", model.CoverImageURL,
                    "@videoURL", model.VideoURL,
                    "@duration", model.Duration,
                    "@MovieNameURL", model.MovieNameURL,
                    "@TrailerURL", model.TrailerURL);
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
