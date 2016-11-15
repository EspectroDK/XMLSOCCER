using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLSoccerCOM
{
    public class Match
    {
        public int Id { get; set; }
        public int? FixtureMatch_Id { get; set; }
        public DateTime? Date { get; set; }
        public string Location { get; set; }
        public int? Round { get; set; }
        public string Time { get; set; }
        public string Spectators { get; set; }
        public string League { get; set; }
        public string HomeTeam { get; set; }
        public int HomeTeam_Id { get; set; }
        public int? HomeCorners { get; set; }
        public int? HomeGoals { get; set; }
        public int? HalfTimeHomeGoals { get; set; }
        public int? HomeShots { get; set; }
        public int? HomeShotsOnTarget { get; set; }
        public int? HomeFouls { get; set; }
        public string[] HomeSubDetails { get; set; }
        public string[] AwaySubDetails { get; set; }
        public string[] HomeGoalDetails { get; set; }
        public string HomeLineupGoalkeeper { get; set; }
        public string[] HomeLineupDefense { get; set; }
        public string[] HomeLineupMidfield { get; set; }
        public string[] HomeLineupForward { get; set; }
        public string[] HomeLineupSubstitutes { get; set; }
        public string HomeLineupCoach { get; set; }
        public int? HomeYellowCards { get; set; }
        public int? HomeRedCards { get; set; }
        public string HomeTeamFormation { get; set; }
        public string AwayTeam { get; set; }
        public int AwayTeam_Id { get; set; }
        public int? AwayCorners { get; set; }
        public int? AwayGoals { get; set; }
        public int? HalfTimeAwayGoals { get; set; }
        public int? AwayShots { get; set; }
        public int? AwayShotsOnTarget { get; set; }
        public int? AwayFouls { get; set; }
        public string[] AwayGoalDetails { get; set; }
        public string AwayLineupGoalkeeper { get; set; }
        public string[] AwayLineupDefense { get; set; }
        public string[] AwayLineupMidfield { get; set; }
        public string[] AwayLineupForward { get; set; }
        public string[] AwayLineupSubstitutes { get; set; }
        public string AwayLineupCoach { get; set; }
        public int? AwayYellowCards { get; set; }
        public int? AwayRedCards { get; set; }
        public string AwayTeamFormation { get; set; }
        public string[] HomeTeamYellowCardDetails { get; set; }
        public string[] AwayTeamYellowCardDetails { get; set; }
        public string[] HomeTeamRedCardDetails { get; set; }
        public string[] AwayTeamRedCardDetails { get; set; }
        public string Group { get; set; }
        public string Group_Id { get; set; }
        public Boolean? HasBeenRescheduled { get; set; }
    }
}
