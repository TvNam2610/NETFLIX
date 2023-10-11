using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IMovieRespository
    {
        MovieModel GetbyID(int id);

        bool Create(MovieModel model);

        bool Update(MovieModel model);

        bool Delete(int id);

        public List<MovieModel> Search(int pageIndex, int pageSize, out long total, string ten_phim, string the_loai);

    }
}
