using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLSoccerCOM
{
    public class Topscorer
    {
        public int Rank { get; set; }
        public string Name { get; set; }
        public string TeamName { get; set; }
        public int Team_Id { get; set; }
        public string Nationality { get; set; }
        public int Goals { get; set; }
        public int? FirstScorer { get; set; }
        public int? Penalties { get; set; }
        public int? MissedPenalties { get; set; }
    }
}
