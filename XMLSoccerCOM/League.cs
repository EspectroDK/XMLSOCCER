using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLSoccerCOM
{
    public class League
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string Historical_Data { get; set; }
        public bool Fixtures { get; set; }
        public bool Livescore { get; set; }
        public int NumberOfMatches { get; set; }
        public DateTime? LatestMatchResult { get; set; }
    }
}
