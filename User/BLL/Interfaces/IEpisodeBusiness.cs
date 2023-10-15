using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IEpisodeBusiness
    {
        EpisodeModel GetbyID(int id);

        bool Create(EpisodeModel model);

        bool Update(EpisodeModel model);

        bool Delete(int id);

        public List<EpisodeModel> Search(int pageIndex, int pageSize, out long total, string ten_phim, string the_loai);
    }
}
