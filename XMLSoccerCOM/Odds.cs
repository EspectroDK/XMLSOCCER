using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLSoccerCOM
{
    public class Odds
    {        
        public string Name { get; set; }
        public string URL { get; set; }
        public string Type { get; set; }
        public double Home { get; set; }
        public double Draw { get; set; }
        public double Away { get; set; }
    }
}
