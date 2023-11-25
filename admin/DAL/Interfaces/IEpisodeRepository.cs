using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IEpisodeRepository
    {
        EpisodeModel GetbyID(int id);

        bool Create(EpisodeModel model);

        bool Update(EpisodeModel model);

        bool Delete(int id);

        bool AddMovieForEpisode(AddMovieRequestDto model);
        bool UpdateMovieForEpisode(MovieDto model);

        public List<EpisodeModel> Search(int pageIndex, int pageSize, out long total, string name);
    }
}
