using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class GenreModel
    {
        public string Genre { get; set; }
        public List<MovieModel> list_json_Movies { get; set; } // Lấy về list json của những tập phim có trong seris
    }
}
