using BLL.Interfaces;
using DAL.Interfaces;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class GenreBusiness : IGenreBusiness
    {
        private IGenreRepository _res;

        public GenreBusiness(IGenreRepository res)
        {
            _res = res;
        }
        public bool Create(GenreModel model)
        {
            return _res.Create(model);
        }

        public bool Delete(int id)
        {
            return _res.Delete(id);
        }

        public List<GenreModel> GetAll()
        {
            return _res.GetAll();
        }

        public GenreModel GetbyID(int id)
        {
            return _res.GetbyID(id);
        }

        public bool Update(GenreModel model)
        {
            return _res.Update(model);
        }
    }
}
