using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLSoccerCOM
{
    public class MatchOdds
    {
        public int FixtureMatch_Id { get; set; }
        public List<Odds> Odds { get; set; }
    }
}
