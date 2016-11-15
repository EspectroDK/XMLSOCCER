using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLSoccerCOM
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double? Height { get; set; }
        public double? Weight { get; set; }
        public string Nationality { get; set; }
        public string Position { get; set; }
        public int Team_Id { get; set; }
        public int? PlayerNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? DateOfSigning { get; set; }
        public String Signing { get; set; }
    }
}
