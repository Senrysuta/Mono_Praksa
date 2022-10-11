using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Common
{
    public class Filtering
    {
        public string Title { get; set; }
        public DateTime YearMin { get; set; }
        public DateTime YearMax { get; set; }
        public string Language { get; set; } //dropdown
    }
}
