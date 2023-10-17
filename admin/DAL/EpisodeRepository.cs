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

        public List<EpisodeModel> Search(int pageIndex, int pageSize, out long total, string ten_phim, string the_loai)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _db.ExecuteSProcedureReturnDataTable(out msgError, "sp_episode_search",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                    "@title ", ten_phim,
                    "@genre", the_loai);
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

    }
}
