using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLSoccerCOM
{
    public class TeamLeagueStanding
    {
        public string Team { get; set; }
        public int Team_Id { get; set; }
        public int Played { get; set; }
        public int PlayedAtHome { get; set; }
        public int PlayedAway { get; set; }
        public int Won { get; set; }
        public int Draw { get; set; }
        public int Lost { get; set; }
        public int NumberOfShots { get; set; }
        public int YellowCards { get; set; }
        public int RedCards { get; set; }
        public int Goals_For { get; set; }
        public int Goals_Against { get; set; }
        public int Goal_Difference { get; set; }
        public int Points { get; set; }
        public int? Group_Id { get; set; }
        public string Group { get; set; }
    }
}
