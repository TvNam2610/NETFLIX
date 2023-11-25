using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IGenreRepository
    {
        List<GenreModel> GetAll();
        GenreModel GetbyID(int id);
        bool Create(GenreModel model);
        bool Update(GenreModel model);
        bool Delete(int id);
    }
}
