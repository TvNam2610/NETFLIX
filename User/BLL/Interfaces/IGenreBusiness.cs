using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IGenreBusiness
    {
        List<GenreDtoWithMovie> getAllWithMovie();
        List<GenreDtoWithEpisode> getAllWithEpisode();

    }
}
