using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class WatchHistoryModel
    {
        public int HistoryID { get; set; }
        public string Username { get; set; }
        public string Title { get; set; }
        public DateTime WatchDate { get; set; }

    }
}
