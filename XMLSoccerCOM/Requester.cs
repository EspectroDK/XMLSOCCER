using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml;

namespace XMLSoccerCOM
{
    public class Requester
    {
        protected string apiKey;
        protected bool proMode;
        protected string accountInformation;

        public Requester(string apiKey, bool proMode = false)
        {
            this.apiKey = apiKey;
            this.proMode = proMode;
        }


        /// <summary>
        /// Gets a list of matches within the date-interval specified. "ID" will always be 0 as all ID's a recorded in to the Match "FixtureMatch_Id" field. You shouldn't use this method if you are trying to get results from already played matches, as this method will only return a very limited amount of data per match.
        /// </summary>
        /// <param name="dateFrom">Date start</param>
        /// <param name="dateTo">Date end</param>
        /// <returns>List of "Match" object within the desired date interval for all leagues</returns>
        public List<Match> GetFixturesByDateInterval(DateTime dateFrom, DateTime dateTo)
        {
            ProService.FootballDataSoapClient xmlSoccerServicePro = new ProService.FootballDataSoapClient();
            DemoService.FootballDataDemoSoapClient xmlSoccerServiceDemo = new DemoService.FootballDataDemoSoapClient();
            XDocument xDoc = new XDocument();

            if (proMode)
                xDoc = XDocument.Load(new XmlNodeReader(xmlSoccerServicePro.GetFixturesByDateInterval(apiKey, convertDateTimeToDateTimeString(dateFrom), convertDateTimeToDateTimeString(dateTo))));
            else
                xDoc = XDocument.Load(new XmlNodeReader(xmlSoccerServiceDemo.GetFixturesByDateInterval(apiKey, convertDateTimeToDateTimeString(dateFrom), convertDateTimeToDateTimeString(dateTo))));
            CheckForErrors(xDoc);
            List<Match> matches = new List<Match>();
            matches = (from b in xDoc.Descendants("Match")
                       select new Match() { FixtureMatch_Id = b.Element("Id") != null ? Int32.Parse(b.Element("Id").Value) : 0, Date = DateTime.Parse(b.Element("Date").Value), Round = b.Element("Round") != null ? Int32.Parse(b.Element("Round").Value) : 0, Spectators = b.Element("Spectators") != null ? b.Element("Spectators").Value : null, League = b.Element("League").Value, HomeTeam = b.Element("HomeTeam").Value, HomeTeam_Id = Int32.Parse(b.Element("HomeTeam_Id").Value), HomeGoals = b.Element("HomeGoals") != null ? Int32.Parse(b.Element("HomeGoals").Value) : 0, HomeCorners = b.Element("HomeCorners") != null ? Int32.Parse(b.Element("HomeCorners").Value) : 0, HalfTimeHomeGoals = b.Element("HalfTimeHomeGoals") != null ? Int32.Parse(b.Element("HalfTimeHomeGoals").Value) : 0, HomeShots = b.Element("HomeShots") != null ? Int32.Parse(b.Element("HomeShots").Value) : 0, HomeShotsOnTarget = b.Element("HomeShotsOnTarget") != null ? Int32.Parse(b.Element("HomeShotsOnTarget").Value) : 0, HomeFouls = b.Element("HomeFouls") != null ? Int32.Parse(b.Element("HomeFouls").Value) : 0, AwayTeam = b.Element("AwayTeam").Value, AwayTeam_Id = Int32.Parse(b.Element("AwayTeam_Id").Value), AwayGoals = b.Element("AwayGoals") != null ? Int32.Parse(b.Element("AwayGoals").Value) : 0, AwayCorners = b.Element("AwayCorners") != null ? Int32.Parse(b.Element("AwayCorners").Value) : 0, HalfTimeAwayGoals = b.Element("HalfTimeAwayGoals") != null ? Int32.Parse(b.Element("HalfTimeAwayGoals").Value) : 0, AwayShots = b.Element("AwayShots") != null ? Int32.Parse(b.Element("AwayShots").Value) : 0, AwayShotsOnTarget = b.Element("AwayShotsOnTarget") != null ? Int32.Parse(b.Element("AwayShotsOnTarget").Value) : 0, AwayFouls = b.Element("AwayFouls") != null ? Int32.Parse(b.Element("AwayFouls").Value) : 0, Time = b.Element("Time") != null ? b.Element("Time").Value : null, Location = b.Element("Location") != null ? b.Element("Location").Value : null, HomeTeamYellowCardDetails = b.Element("HomeTeamYellowCardDetails") != null ? b.Element("HomeTeamYellowCardDetails").Value.Split(';') : null, AwayTeamYellowCardDetails = b.Element("AwayTeamYellowCardDetails") != null ? b.Element("AwayTeamYellowCardDetails").Value.Split(';') : null, HomeTeamRedCardDetails = b.Element("HomeTeamRedCardDetails") != null ? b.Element("HomeTeamRedCardDetails").Value.Split(';') : null, AwayTeamRedCardDetails = b.Element("AwayTeamRedCardDetails") != null ? b.Element("AwayTeamRedCardDetails").Value.Split(';') : null, HomeGoalDetails = b.Element("HomeGoalDetails") != null ? b.Element("HomeGoalDetails").Value.Split(';') : null, AwayGoalDetails = b.Element("AwayGoalDetails") != null ? b.Element("AwayGoalDetails").Value.Split(';') : null, HomeLineupDefense = b.Element("HomeLineupDefense") != null ? b.Element("HomeLineupDefense").Value.Split(';') : null, HomeLineupGoalkeeper = b.Element("HomeLineupGoalkeeper") != null ? b.Element("HomeLineupGoalkeeper").Value : null, HomeLineupMidfield = b.Element("HomeLineupMidfield") != null ? b.Element("HomeLineupMidfield").Value.Split(';') : null, HomeLineupForward = b.Element("HomeLineupForward") != null ? b.Element("HomeLineupForward").Value.Split(';') : null, AwayLineupGoalkeeper = b.Element("AwayLineupGoalkeeper") != null ? b.Element("AwayLineupGoalkeeper").Value : null, AwayLineupDefense = b.Element("AwayLineupDefense") != null ? b.Element("AwayLineupDefense").Value.Split(';') : null, AwayLineupMidfield = b.Element("AwayLineupMidfield") != null ? b.Element("AwayLineupMidfield").Value.Split(';') : null, AwayLineupForward = b.Element("AwayLineupForward") != null ? b.Element("AwayLineupForward").Value.Split(';') : null, HomeSubDetails = b.Element("HomeSubDetails") != null ? b.Element("HomeSubDetails").Value.Split(';') : null, AwaySubDetails = b.Element("AwaySubDetails") != null ? b.Element("AwaySubDetails").Value.Split(';') : null, HomeTeamFormation = b.Element("HomeTeamFormation") != null ? b.Element("HomeTeamFormation").Value : null, AwayTeamFormation = b.Element("AwayTeamFormation") != null ? b.Element("AwayTeamFormation").Value : null, Group = b.Element("Group") != null ? b.Element("Group").Value : null, Group_Id = b.Element("Group_Id") != null ? b.Element("Group_Id").Value : null, HasBeenRescheduled = b.Element("HasBeenRescheduled") != null ? Boolean.Parse(b.Element("HasBeenRescheduled").Value) : false }
            ).ToList();
            return matches;
        }

        /// <summary>
        /// Gets a list of matches within the date-interval specified and in the specified league. "ID" will always be 0 as all ID's a recorded in to the Match "FixtureMatch_Id" field. You shouldn't use this method if you are trying to get results from already played matches, as this method will only return a very limited amount of data per match.
        /// </summary>
        /// <param name="league">Use full name or ID - see xmlsoccer.wikia.com/wiki/Input_data_formats</param>
        /// <param name="dateFrom">Date start</param>
        /// <param name="dateTo">Date end</param>
        /// <returns>List of "Match" object within the desired date interval for the specified league</returns>
        public List<Match> GetFixturesByDateIntervalAndLeague(DateTime dateFrom, DateTime dateTo, string league)
        {
            ProService.FootballDataSoapClient xmlSoccerServicePro = new ProService.FootballDataSoapClient();
            DemoService.FootballDataDemoSoapClient xmlSoccerServiceDemo = new DemoService.FootballDataDemoSoapClient();
            XDocument xDoc = new XDocument();

            if (proMode)
                xDoc = XDocument.Load(new XmlNodeReader(xmlSoccerServicePro.GetFixturesByDateIntervalAndLeague(league, apiKey, convertDateTimeToDateTimeString(dateFrom), convertDateTimeToDateTimeString(dateTo))));
            else
                xDoc = XDocument.Load(new XmlNodeReader(xmlSoccerServiceDemo.GetFixturesByDateIntervalAndLeague(league, apiKey, convertDateTimeToDateTimeString(dateFrom), convertDateTimeToDateTimeString(dateTo))));
            CheckForErrors(xDoc);
            List<Match> matches = new List<Match>();
            matches = (from b in xDoc.Descendants("Match")
                       select new Match() { FixtureMatch_Id = b.Element("Id") != null ? Int32.Parse(b.Element("Id").Value) : 0, Date = DateTime.Parse(b.Element("Date").Value), Round = b.Element("Round") != null ? Int32.Parse(b.Element("Round").Value) : 0, Spectators = b.Element("Spectators") != null ? b.Element("Spectators").Value : null, League = b.Element("League").Value, HomeTeam = b.Element("HomeTeam").Value, HomeTeam_Id = Int32.Parse(b.Element("HomeTeam_Id").Value), HomeGoals = b.Element("HomeGoals") != null ? Int32.Parse(b.Element("HomeGoals").Value) : 0, HomeCorners = b.Element("HomeCorners") != null ? Int32.Parse(b.Element("HomeCorners").Value) : 0, HalfTimeHomeGoals = b.Element("HalfTimeHomeGoals") != null ? Int32.Parse(b.Element("HalfTimeHomeGoals").Value) : 0, HomeShots = b.Element("HomeShots") != null ? Int32.Parse(b.Element("HomeShots").Value) : 0, HomeShotsOnTarget = b.Element("HomeShotsOnTarget") != null ? Int32.Parse(b.Element("HomeShotsOnTarget").Value) : 0, HomeFouls = b.Element("HomeFouls") != null ? Int32.Parse(b.Element("HomeFouls").Value) : 0, AwayTeam = b.Element("AwayTeam").Value, AwayTeam_Id = Int32.Parse(b.Element("AwayTeam_Id").Value), AwayGoals = b.Element("AwayGoals") != null ? Int32.Parse(b.Element("AwayGoals").Value) : 0, AwayCorners = b.Element("AwayCorners") != null ? Int32.Parse(b.Element("AwayCorners").Value) : 0, HalfTimeAwayGoals = b.Element("HalfTimeAwayGoals") != null ? Int32.Parse(b.Element("HalfTimeAwayGoals").Value) : 0, AwayShots = b.Element("AwayShots") != null ? Int32.Parse(b.Element("AwayShots").Value) : 0, AwayShotsOnTarget = b.Element("AwayShotsOnTarget") != null ? Int32.Parse(b.Element("AwayShotsOnTarget").Value) : 0, AwayFouls = b.Element("AwayFouls") != null ? Int32.Parse(b.Element("AwayFouls").Value) : 0, Time = b.Element("Time") != null ? b.Element("Time").Value : null, Location = b.Element("Location") != null ? b.Element("Location").Value : null, HomeTeamYellowCardDetails = b.Element("HomeTeamYellowCardDetails") != null ? b.Element("HomeTeamYellowCardDetails").Value.Split(';') : null, AwayTeamYellowCardDetails = b.Element("AwayTeamYellowCardDetails") != null ? b.Element("AwayTeamYellowCardDetails").Value.Split(';') : null, HomeTeamRedCardDetails = b.Element("HomeTeamRedCardDetails") != null ? b.Element("HomeTeamRedCardDetails").Value.Split(';') : null, AwayTeamRedCardDetails = b.Element("AwayTeamRedCardDetails") != null ? b.Element("AwayTeamRedCardDetails").Value.Split(';') : null, HomeGoalDetails = b.Element("HomeGoalDetails") != null ? b.Element("HomeGoalDetails").Value.Split(';') : null, AwayGoalDetails = b.Element("AwayGoalDetails") != null ? b.Element("AwayGoalDetails").Value.Split(';') : null, HomeLineupDefense = b.Element("HomeLineupDefense") != null ? b.Element("HomeLineupDefense").Value.Split(';') : null, HomeLineupGoalkeeper = b.Element("HomeLineupGoalkeeper") != null ? b.Element("HomeLineupGoalkeeper").Value : null, HomeLineupMidfield = b.Element("HomeLineupMidfield") != null ? b.Element("HomeLineupMidfield").Value.Split(';') : null, HomeLineupForward = b.Element("HomeLineupForward") != null ? b.Element("HomeLineupForward").Value.Split(';') : null, AwayLineupGoalkeeper = b.Element("AwayLineupGoalkeeper") != null ? b.Element("AwayLineupGoalkeeper").Value : null, AwayLineupDefense = b.Element("AwayLineupDefense") != null ? b.Element("AwayLineupDefense").Value.Split(';') : null, AwayLineupMidfield = b.Element("AwayLineupMidfield") != null ? b.Element("AwayLineupMidfield").Value.Split(';') : null, AwayLineupForward = b.Element("AwayLineupForward") != null ? b.Element("AwayLineupForward").Value.Split(';') : null, HomeSubDetails = b.Element("HomeSubDetails") != null ? b.Element("HomeSubDetails").Value.Split(';') : null, AwaySubDetails = b.Element("AwaySubDetails") != null ? b.Element("AwaySubDetails").Value.Split(';') : null, HomeTeamFormation = b.Element("HomeTeamFormation") != null ? b.Element("HomeTeamFormation").Value : null, AwayTeamFormation = b.Element("AwayTeamFormation") != null ? b.Element("AwayTeamFormation").Value : null, Group = b.Element("Group") != null ? b.Element("Group").Value : null, Group_Id = b.Element("Group_Id") != null ? b.Element("Group_Id").Value : null, HasBeenRescheduled = b.Element("HasBeenRescheduled") != null ? Boolean.Parse(b.Element("HasBeenRescheduled").Value) : false }
            ).ToList();
            return matches;
        }


        /// <summary>
        /// Gets a list of fixtures for a given team in a given date interval
        /// </summary>
        /// <param name="dateFrom">Date start</param>
        /// <param name="dateTo">Date end</param>
        /// <param name="teamId">Full name OR numeric ID of team</param>
        /// <returns>List of "Match" object within the desired date interval for the desired team</returns>
        public List<Match> GetFixturesByDateIntervalAndTeam(DateTime dateFrom, DateTime dateTo, string teamId)
        {
            ProService.FootballDataSoapClient xmlSoccerServicePro = new ProService.FootballDataSoapClient();
            DemoService.FootballDataDemoSoapClient xmlSoccerServiceDemo = new DemoService.FootballDataDemoSoapClient();
            XDocument xDoc = new XDocument();

            if (proMode)
                xDoc = XDocument.Load(new XmlNodeReader(xmlSoccerServicePro.GetFixturesByDateIntervalAndTeam(apiKey, convertDateTimeToDateTimeString(dateFrom), convertDateTimeToDateTimeString(dateTo), teamId)));
            else
                xDoc = XDocument.Load(new XmlNodeReader(xmlSoccerServiceDemo.GetFixturesByDateIntervalAndTeam(apiKey, convertDateTimeToDateTimeString(dateFrom), convertDateTimeToDateTimeString(dateTo), teamId)));
            CheckForErrors(xDoc);
            List<Match> matches = new List<Match>();
            matches = (from b in xDoc.Descendants("Match")
                       select new Match() { FixtureMatch_Id = b.Element("Id") != null ? Int32.Parse(b.Element("Id").Value) : 0, Date = DateTime.Parse(b.Element("Date").Value), Round = b.Element("Round") != null ? Int32.Parse(b.Element("Round").Value) : 0, Spectators = b.Element("Spectators") != null ? b.Element("Spectators").Value : null, League = b.Element("League").Value, HomeTeam = b.Element("HomeTeam").Value, HomeTeam_Id = Int32.Parse(b.Element("HomeTeam_Id").Value), HomeGoals = b.Element("HomeGoals") != null ? Int32.Parse(b.Element("HomeGoals").Value) : 0, HomeCorners = b.Element("HomeCorners") != null ? Int32.Parse(b.Element("HomeCorners").Value) : 0, HalfTimeHomeGoals = b.Element("HalfTimeHomeGoals") != null ? Int32.Parse(b.Element("HalfTimeHomeGoals").Value) : 0, HomeShots = b.Element("HomeShots") != null ? Int32.Parse(b.Element("HomeShots").Value) : 0, HomeShotsOnTarget = b.Element("HomeShotsOnTarget") != null ? Int32.Parse(b.Element("HomeShotsOnTarget").Value) : 0, HomeFouls = b.Element("HomeFouls") != null ? Int32.Parse(b.Element("HomeFouls").Value) : 0, AwayTeam = b.Element("AwayTeam").Value, AwayTeam_Id = Int32.Parse(b.Element("AwayTeam_Id").Value), AwayGoals = b.Element("AwayGoals") != null ? Int32.Parse(b.Element("AwayGoals").Value) : 0, AwayCorners = b.Element("AwayCorners") != null ? Int32.Parse(b.Element("AwayCorners").Value) : 0, HalfTimeAwayGoals = b.Element("HalfTimeAwayGoals") != null ? Int32.Parse(b.Element("HalfTimeAwayGoals").Value) : 0, AwayShots = b.Element("AwayShots") != null ? Int32.Parse(b.Element("AwayShots").Value) : 0, AwayShotsOnTarget = b.Element("AwayShotsOnTarget") != null ? Int32.Parse(b.Element("AwayShotsOnTarget").Value) : 0, AwayFouls = b.Element("AwayFouls") != null ? Int32.Parse(b.Element("AwayFouls").Value) : 0, Time = b.Element("Time") != null ? b.Element("Time").Value : null, Location = b.Element("Location") != null ? b.Element("Location").Value : null, HomeTeamYellowCardDetails = b.Element("HomeTeamYellowCardDetails") != null ? b.Element("HomeTeamYellowCardDetails").Value.Split(';') : null, AwayTeamYellowCardDetails = b.Element("AwayTeamYellowCardDetails") != null ? b.Element("AwayTeamYellowCardDetails").Value.Split(';') : null, HomeTeamRedCardDetails = b.Element("HomeTeamRedCardDetails") != null ? b.Element("HomeTeamRedCardDetails").Value.Split(';') : null, AwayTeamRedCardDetails = b.Element("AwayTeamRedCardDetails") != null ? b.Element("AwayTeamRedCardDetails").Value.Split(';') : null, HomeGoalDetails = b.Element("HomeGoalDetails") != null ? b.Element("HomeGoalDetails").Value.Split(';') : null, AwayGoalDetails = b.Element("AwayGoalDetails") != null ? b.Element("AwayGoalDetails").Value.Split(';') : null, HomeLineupDefense = b.Element("HomeLineupDefense") != null ? b.Element("HomeLineupDefense").Value.Split(';') : null, HomeLineupGoalkeeper = b.Element("HomeLineupGoalkeeper") != null ? b.Element("HomeLineupGoalkeeper").Value : null, HomeLineupMidfield = b.Element("HomeLineupMidfield") != null ? b.Element("HomeLineupMidfield").Value.Split(';') : null, HomeLineupForward = b.Element("HomeLineupForward") != null ? b.Element("HomeLineupForward").Value.Split(';') : null, AwayLineupGoalkeeper = b.Element("AwayLineupGoalkeeper") != null ? b.Element("AwayLineupGoalkeeper").Value : null, AwayLineupDefense = b.Element("AwayLineupDefense") != null ? b.Element("AwayLineupDefense").Value.Split(';') : null, AwayLineupMidfield = b.Element("AwayLineupMidfield") != null ? b.Element("AwayLineupMidfield").Value.Split(';') : null, AwayLineupForward = b.Element("AwayLineupForward") != null ? b.Element("AwayLineupForward").Value.Split(';') : null, HomeSubDetails = b.Element("HomeSubDetails") != null ? b.Element("HomeSubDetails").Value.Split(';') : null, AwaySubDetails = b.Element("AwaySubDetails") != null ? b.Element("AwaySubDetails").Value.Split(';') : null, HomeTeamFormation = b.Element("HomeTeamFormation") != null ? b.Element("HomeTeamFormation").Value : null, AwayTeamFormation = b.Element("AwayTeamFormation") != null ? b.Element("AwayTeamFormation").Value : null, Group = b.Element("Group") != null ? b.Element("Group").Value : null, Group_Id = b.Element("Group_Id") != null ? b.Element("Group_Id").Value : null, HasBeenRescheduled = b.Element("HasBeenRescheduled") != null ? Boolean.Parse(b.Element("HasBeenRescheduled").Value) : false }
            ).ToList();
            return matches;
        }

        /// <summary>
        /// Get fixtures for the entire season
        /// </summary>
        /// <param name="league">Specify name or numeric ID of league</param>
        /// <param name="seasonStartYear">The year the season started</param>
        /// <returns>All fixtures for the season</returns>
        public List<Match> GetFixturesByLeagueAndSeason(string league, int seasonStartYear)
        {
            string season = seasonStartYear.ToString().Substring(2) + (seasonStartYear + 1).ToString().Substring(2);
            ProService.FootballDataSoapClient xmlSoccerServicePro = new ProService.FootballDataSoapClient();
            DemoService.FootballDataDemoSoapClient xmlSoccerServiceDemo = new DemoService.FootballDataDemoSoapClient();
            XDocument xDoc = new XDocument();

            if (proMode)
                xDoc = XDocument.Load(new XmlNodeReader(xmlSoccerServicePro.GetFixturesByLeagueAndSeason(apiKey, season, league)));
            else
                xDoc = XDocument.Load(new XmlNodeReader(xmlSoccerServiceDemo.GetFixturesByLeagueAndSeason(apiKey, season, league)));
            CheckForErrors(xDoc);
            List<Match> matches = new List<Match>();
            matches = (from b in xDoc.Descendants("Match")
                       select new Match() { FixtureMatch_Id = b.Element("Id") != null ? Int32.Parse(b.Element("Id").Value) : 0, Date = DateTime.Parse(b.Element("Date").Value), Round = b.Element("Round") != null ? Int32.Parse(b.Element("Round").Value) : 0, Spectators = b.Element("Spectators") != null ? b.Element("Spectators").Value : null, League = b.Element("League").Value, HomeTeam = b.Element("HomeTeam").Value, HomeTeam_Id = Int32.Parse(b.Element("HomeTeam_Id").Value), HomeGoals = b.Element("HomeGoals") != null ? Int32.Parse(b.Element("HomeGoals").Value) : 0, HomeCorners = b.Element("HomeCorners") != null ? Int32.Parse(b.Element("HomeCorners").Value) : 0, HalfTimeHomeGoals = b.Element("HalfTimeHomeGoals") != null ? Int32.Parse(b.Element("HalfTimeHomeGoals").Value) : 0, HomeShots = b.Element("HomeShots") != null ? Int32.Parse(b.Element("HomeShots").Value) : 0, HomeShotsOnTarget = b.Element("HomeShotsOnTarget") != null ? Int32.Parse(b.Element("HomeShotsOnTarget").Value) : 0, HomeFouls = b.Element("HomeFouls") != null ? Int32.Parse(b.Element("HomeFouls").Value) : 0, AwayTeam = b.Element("AwayTeam").Value, AwayTeam_Id = Int32.Parse(b.Element("AwayTeam_Id").Value), AwayGoals = b.Element("AwayGoals") != null ? Int32.Parse(b.Element("AwayGoals").Value) : 0, AwayCorners = b.Element("AwayCorners") != null ? Int32.Parse(b.Element("AwayCorners").Value) : 0, HalfTimeAwayGoals = b.Element("HalfTimeAwayGoals") != null ? Int32.Parse(b.Element("HalfTimeAwayGoals").Value) : 0, AwayShots = b.Element("AwayShots") != null ? Int32.Parse(b.Element("AwayShots").Value) : 0, AwayShotsOnTarget = b.Element("AwayShotsOnTarget") != null ? Int32.Parse(b.Element("AwayShotsOnTarget").Value) : 0, AwayFouls = b.Element("AwayFouls") != null ? Int32.Parse(b.Element("AwayFouls").Value) : 0, Time = b.Element("Time") != null ? b.Element("Time").Value : null, Location = b.Element("Location") != null ? b.Element("Location").Value : null, HomeTeamYellowCardDetails = b.Element("HomeTeamYellowCardDetails") != null ? b.Element("HomeTeamYellowCardDetails").Value.Split(';') : null, AwayTeamYellowCardDetails = b.Element("AwayTeamYellowCardDetails") != null ? b.Element("AwayTeamYellowCardDetails").Value.Split(';') : null, HomeTeamRedCardDetails = b.Element("HomeTeamRedCardDetails") != null ? b.Element("HomeTeamRedCardDetails").Value.Split(';') : null, AwayTeamRedCardDetails = b.Element("AwayTeamRedCardDetails") != null ? b.Element("AwayTeamRedCardDetails").Value.Split(';') : null, HomeGoalDetails = b.Element("HomeGoalDetails") != null ? b.Element("HomeGoalDetails").Value.Split(';') : null, AwayGoalDetails = b.Element("AwayGoalDetails") != null ? b.Element("AwayGoalDetails").Value.Split(';') : null, HomeLineupDefense = b.Element("HomeLineupDefense") != null ? b.Element("HomeLineupDefense").Value.Split(';') : null, HomeLineupGoalkeeper = b.Element("HomeLineupGoalkeeper") != null ? b.Element("HomeLineupGoalkeeper").Value : null, HomeLineupMidfield = b.Element("HomeLineupMidfield") != null ? b.Element("HomeLineupMidfield").Value.Split(';') : null, HomeLineupForward = b.Element("HomeLineupForward") != null ? b.Element("HomeLineupForward").Value.Split(';') : null, AwayLineupGoalkeeper = b.Element("AwayLineupGoalkeeper") != null ? b.Element("AwayLineupGoalkeeper").Value : null, AwayLineupDefense = b.Element("AwayLineupDefense") != null ? b.Element("AwayLineupDefense").Value.Split(';') : null, AwayLineupMidfield = b.Element("AwayLineupMidfield") != null ? b.Element("AwayLineupMidfield").Value.Split(';') : null, AwayLineupForward = b.Element("AwayLineupForward") != null ? b.Element("AwayLineupForward").Value.Split(';') : null, HomeSubDetails = b.Element("HomeSubDetails") != null ? b.Element("HomeSubDetails").Value.Split(';') : null, AwaySubDetails = b.Element("AwaySubDetails") != null ? b.Element("AwaySubDetails").Value.Split(';') : null, HomeTeamFormation = b.Element("HomeTeamFormation") != null ? b.Element("HomeTeamFormation").Value : null, AwayTeamFormation = b.Element("AwayTeamFormation") != null ? b.Element("AwayTeamFormation").Value : null, Group = b.Element("Group") != null ? b.Element("Group").Value : null, Group_Id = b.Element("Group_Id") != null ? b.Element("Group_Id").Value : null }
            ).ToList();
            return matches;
        }


        /// <summary>
        /// Gets a specific match after it has finished. Is used to get more information on the match.
        /// </summary>
        /// <param name="fixtureMatch_Id"></param>
        /// <returns></returns>
        public Match GetHistoricMatchByFixtureMatchID(int fixtureMatch_Id)
        {
            ProService.FootballDataSoapClient xmlSoccerServicePro = new ProService.FootballDataSoapClient();
            DemoService.FootballDataDemoSoapClient xmlSoccerServiceDemo = new DemoService.FootballDataDemoSoapClient();
            XDocument xDoc = new XDocument();

            if (proMode)
                xDoc = XDocument.Load(new XmlNodeReader(xmlSoccerServicePro.GetHistoricMatchesByFixtureMatchID(apiKey, fixtureMatch_Id)));
            else
                xDoc = XDocument.Load(new XmlNodeReader(xmlSoccerServiceDemo.GetHistoricMatchesByFixtureMatchID(apiKey, fixtureMatch_Id)));
            CheckForErrors(xDoc);
            Match match = new Match();
            match = (from b in xDoc.Descendants("Match")
                     select new Match() { Id = Int32.Parse(b.Element("Id").Value), FixtureMatch_Id = b.Element("FixtureMatch_Id") != null ? Int32.Parse(b.Element("FixtureMatch_Id").Value) : 0, Date = DateTime.Parse(b.Element("Date").Value), Round = b.Element("Round") != null ? Int32.Parse(b.Element("Round").Value) : 0, Spectators = b.Element("Spectators") != null ? b.Element("Spectators").Value : null, League = b.Element("League").Value, HomeTeam = b.Element("HomeTeam").Value, HomeTeam_Id = Int32.Parse(b.Element("HomeTeam_Id").Value), HomeGoals = Int32.Parse(b.Element("HomeGoals").Value), HomeCorners = b.Element("HomeCorners") != null ? Int32.Parse(b.Element("HomeCorners").Value) : 0, HalfTimeHomeGoals = b.Element("HalfTimeHomeGoals") != null ? Int32.Parse(b.Element("HalfTimeHomeGoals").Value) : 0, HomeShots = b.Element("HomeShots") != null ? Int32.Parse(b.Element("HomeShots").Value) : 0, HomeShotsOnTarget = b.Element("HomeShotsOnTarget") != null ? Int32.Parse(b.Element("HomeShotsOnTarget").Value) : 0, HomeFouls = b.Element("HomeFouls") != null ? Int32.Parse(b.Element("HomeFouls").Value) : 0, AwayTeam = b.Element("AwayTeam").Value, AwayTeam_Id = Int32.Parse(b.Element("AwayTeam_Id").Value), AwayGoals = Int32.Parse(b.Element("AwayGoals").Value), AwayCorners = b.Element("AwayCorners") != null ? Int32.Parse(b.Element("AwayCorners").Value) : 0, HalfTimeAwayGoals = b.Element("HalfTimeAwayGoals") != null ? Int32.Parse(b.Element("HalfTimeAwayGoals").Value) : 0, AwayShots = b.Element("AwayShots") != null ? Int32.Parse(b.Element("AwayShots").Value) : 0, AwayShotsOnTarget = b.Element("AwayShotsOnTarget") != null ? Int32.Parse(b.Element("AwayShotsOnTarget").Value) : 0, AwayFouls = b.Element("AwayFouls") != null ? Int32.Parse(b.Element("AwayFouls").Value) : 0, Time = b.Element("Time") != null ? b.Element("Time").Value : null, Location = b.Element("Location") != null ? b.Element("Location").Value : null, HomeTeamYellowCardDetails = b.Element("HomeTeamYellowCardDetails") != null ? b.Element("HomeTeamYellowCardDetails").Value.Split(';') : null, AwayTeamYellowCardDetails = b.Element("AwayTeamYellowCardDetails") != null ? b.Element("AwayTeamYellowCardDetails").Value.Split(';') : null, HomeTeamRedCardDetails = b.Element("HomeTeamRedCardDetails") != null ? b.Element("HomeTeamRedCardDetails").Value.Split(';') : null, AwayTeamRedCardDetails = b.Element("AwayTeamRedCardDetails") != null ? b.Element("AwayTeamRedCardDetails").Value.Split(';') : null, HomeGoalDetails = b.Element("HomeGoalDetails") != null ? b.Element("HomeGoalDetails").Value.Split(';') : null, AwayGoalDetails = b.Element("AwayGoalDetails") != null ? b.Element("AwayGoalDetails").Value.Split(';') : null, HomeLineupDefense = b.Element("HomeLineupDefense") != null ? b.Element("HomeLineupDefense").Value.Split(';') : null, HomeLineupGoalkeeper = b.Element("HomeLineupGoalkeeper") != null ? b.Element("HomeLineupGoalkeeper").Value : null, HomeLineupMidfield = b.Element("HomeLineupMidfield") != null ? b.Element("HomeLineupMidfield").Value.Split(';') : null, HomeLineupForward = b.Element("HomeLineupForward") != null ? b.Element("HomeLineupForward").Value.Split(';') : null, AwayLineupGoalkeeper = b.Element("AwayLineupGoalkeeper") != null ? b.Element("AwayLineupGoalkeeper").Value : null, AwayLineupMidfield = b.Element("AwayLineupMidfield") != null ? b.Element("AwayLineupMidfield").Value.Split(';') : null, AwayLineupForward = b.Element("AwayLineupForward") != null ? b.Element("AwayLineupForward").Value.Split(';') : null, HomeSubDetails = b.Element("HomeSubDetails") != null ? b.Element("HomeSubDetails").Value.Split(';') : null, AwaySubDetails = b.Element("AwaySubDetails") != null ? b.Element("AwaySubDetails").Value.Split(';') : null, HomeTeamFormation = b.Element("HomeTeamFormation") != null ? b.Element("HomeTeamFormation").Value : null, AwayTeamFormation = b.Element("AwayTeamFormation") != null ? b.Element("AwayTeamFormation").Value : null, HomeLineupSubstitutes = b.Element("HomeLineupSubstitutes") != null ? b.Element("HomeLineupSubstitutes").Value.Split(';') : null, AwayLineupSubstitutes = b.Element("AwayLineupSubstitutes") != null ? b.Element("AwayLineupSubstitutes").Value.Split(';') : null, AwayLineupCoach = b.Element("AwayLineupCoach") != null ? b.Element("AwayLineupCoach").Value : null, HomeLineupCoach = b.Element("HomeLineupCoach") != null ? b.Element("HomeLineupCoach").Value : null, AwayLineupDefense = b.Element("AwayLineupDefense") != null ? b.Element("AwayLineupDefense").Value.Split(';') : null, AwayYellowCards = b.Element("AwayYellowCards") != null ? Int32.Parse(b.Element("AwayYellowCards").Value) : 0, HomeYellowCards = b.Element("HomeYellowCards") != null ? Int32.Parse(b.Element("HomeYellowCards").Value) : 0, HomeRedCards = b.Element("HomeRedCards") != null ? Int32.Parse(b.Element("HomeRedCards").Value) : 0, AwayRedCards = b.Element("AwayRedCards") != null ? Int32.Parse(b.Element("AwayRedCards").Value) : 0, Group = b.Element("Group") != null ? b.Element("Group").Value : null, Group_Id = b.Element("Group_Id") != null ? b.Element("Group_Id").Value : null, HasBeenRescheduled = b.Element("HasBeenRescheduled") != null ? Boolean.Parse(b.Element("HasBeenRescheduled").Value) : false }
            ).FirstOrDefault();
            return match;
        }

        /// <summary>
        /// Retrieve historical matches from a league in a given time interval
        /// </summary>
        /// <param name="dateFrom"></param>
        /// <param name="dateTo"></param>
        /// <param name="league"></param>
        /// <returns></returns>
        public List<Match> GetHistoricMatchesByLeagueAndDateInterval(DateTime dateFrom, DateTime dateTo, string league)
        {
            ProService.FootballDataSoapClient xmlSoccerServicePro = new ProService.FootballDataSoapClient();
            DemoService.FootballDataDemoSoapClient xmlSoccerServiceDemo = new DemoService.FootballDataDemoSoapClient();
            XDocument xDoc = new XDocument();

            if (proMode)
                xDoc = XDocument.Load(new XmlNodeReader(xmlSoccerServicePro.GetHistoricMatchesByLeagueAndDateInterval(apiKey, league, convertDateTimeToDateTimeString(dateFrom), convertDateTimeToDateTimeString(dateTo))));
            else
                xDoc = XDocument.Load(new XmlNodeReader(xmlSoccerServiceDemo.GetHistoricMatchesByLeagueAndDateInterval(apiKey, league, convertDateTimeToDateTimeString(dateFrom), convertDateTimeToDateTimeString(dateTo))));
            CheckForErrors(xDoc);
            List<Match> matches = new List<Match>();
            matches = (from b in xDoc.Descendants("Match")
                       select new Match() { Id = Int32.Parse(b.Element("Id").Value), FixtureMatch_Id = b.Element("FixtureMatch_Id") != null ? Int32.Parse(b.Element("FixtureMatch_Id").Value) : 0, Date = DateTime.Parse(b.Element("Date").Value), Round = b.Element("Round") != null ? Int32.Parse(b.Element("Round").Value) : 0, Spectators = b.Element("Spectators") != null ? b.Element("Spectators").Value : null, League = b.Element("League").Value, HomeTeam = b.Element("HomeTeam").Value, HomeTeam_Id = Int32.Parse(b.Element("HomeTeam_Id").Value), HomeGoals = Int32.Parse(b.Element("HomeGoals").Value), HomeCorners = b.Element("HomeCorners") != null ? Int32.Parse(b.Element("HomeCorners").Value) : 0, HalfTimeHomeGoals = b.Element("HalfTimeHomeGoals") != null ? Int32.Parse(b.Element("HalfTimeHomeGoals").Value) : 0, HomeShots = b.Element("HomeShots") != null ? Int32.Parse(b.Element("HomeShots").Value) : 0, HomeShotsOnTarget = b.Element("HomeShotsOnTarget") != null ? Int32.Parse(b.Element("HomeShotsOnTarget").Value) : 0, HomeFouls = b.Element("HomeFouls") != null ? Int32.Parse(b.Element("HomeFouls").Value) : 0, AwayTeam = b.Element("AwayTeam").Value, AwayTeam_Id = Int32.Parse(b.Element("AwayTeam_Id").Value), AwayGoals = Int32.Parse(b.Element("AwayGoals").Value), AwayCorners = b.Element("AwayCorners") != null ? Int32.Parse(b.Element("AwayCorners").Value) : 0, HalfTimeAwayGoals = b.Element("HalfTimeAwayGoals") != null ? Int32.Parse(b.Element("HalfTimeAwayGoals").Value) : 0, AwayShots = b.Element("AwayShots") != null ? Int32.Parse(b.Element("AwayShots").Value) : 0, AwayShotsOnTarget = b.Element("AwayShotsOnTarget") != null ? Int32.Parse(b.Element("AwayShotsOnTarget").Value) : 0, AwayFouls = b.Element("AwayFouls") != null ? Int32.Parse(b.Element("AwayFouls").Value) : 0, Time = b.Element("Time") != null ? b.Element("Time").Value : null, Location = b.Element("Location") != null ? b.Element("Location").Value : null, HomeTeamYellowCardDetails = b.Element("HomeTeamYellowCardDetails") != null ? b.Element("HomeTeamYellowCardDetails").Value.Split(';') : null, AwayTeamYellowCardDetails = b.Element("AwayTeamYellowCardDetails") != null ? b.Element("AwayTeamYellowCardDetails").Value.Split(';') : null, HomeTeamRedCardDetails = b.Element("HomeTeamRedCardDetails") != null ? b.Element("HomeTeamRedCardDetails").Value.Split(';') : null, AwayTeamRedCardDetails = b.Element("AwayTeamRedCardDetails") != null ? b.Element("AwayTeamRedCardDetails").Value.Split(';') : null, HomeGoalDetails = b.Element("HomeGoalDetails") != null ? b.Element("HomeGoalDetails").Value.Split(';') : null, AwayGoalDetails = b.Element("AwayGoalDetails") != null ? b.Element("AwayGoalDetails").Value.Split(';') : null, HomeLineupDefense = b.Element("HomeLineupDefense") != null ? b.Element("HomeLineupDefense").Value.Split(';') : null, HomeLineupGoalkeeper = b.Element("HomeLineupGoalkeeper") != null ? b.Element("HomeLineupGoalkeeper").Value : null, HomeLineupMidfield = b.Element("HomeLineupMidfield") != null ? b.Element("HomeLineupMidfield").Value.Split(';') : null, HomeLineupForward = b.Element("HomeLineupForward") != null ? b.Element("HomeLineupForward").Value.Split(';') : null, AwayLineupGoalkeeper = b.Element("AwayLineupGoalkeeper") != null ? b.Element("AwayLineupGoalkeeper").Value : null, AwayLineupMidfield = b.Element("AwayLineupMidfield") != null ? b.Element("AwayLineupMidfield").Value.Split(';') : null, AwayLineupForward = b.Element("AwayLineupForward") != null ? b.Element("AwayLineupForward").Value.Split(';') : null, HomeSubDetails = b.Element("HomeSubDetails") != null ? b.Element("HomeSubDetails").Value.Split(';') : null, AwaySubDetails = b.Element("AwaySubDetails") != null ? b.Element("AwaySubDetails").Value.Split(';') : null, HomeTeamFormation = b.Element("HomeTeamFormation") != null ? b.Element("HomeTeamFormation").Value : null, AwayTeamFormation = b.Element("AwayTeamFormation") != null ? b.Element("AwayTeamFormation").Value : null, HomeLineupSubstitutes = b.Element("HomeLineupSubstitutes") != null ? b.Element("HomeLineupSubstitutes").Value.Split(';') : null, AwayLineupSubstitutes = b.Element("AwayLineupSubstitutes") != null ? b.Element("AwayLineupSubstitutes").Value.Split(';') : null, AwayLineupCoach = b.Element("AwayLineupCoach") != null ? b.Element("AwayLineupCoach").Value : null, HomeLineupCoach = b.Element("HomeLineupCoach") != null ? b.Element("HomeLineupCoach").Value : null, AwayLineupDefense = b.Element("AwayLineupDefense") != null ? b.Element("AwayLineupDefense").Value.Split(';') : null, AwayYellowCards = b.Element("AwayYellowCards") != null ? Int32.Parse(b.Element("AwayYellowCards").Value) : 0, HomeYellowCards = b.Element("HomeYellowCards") != null ? Int32.Parse(b.Element("HomeYellowCards").Value) : 0, HomeRedCards = b.Element("HomeRedCards") != null ? Int32.Parse(b.Element("HomeRedCards").Value) : 0, AwayRedCards = b.Element("AwayRedCards") != null ? Int32.Parse(b.Element("AwayRedCards").Value) : 0, Group = b.Element("Group") != null ? b.Element("Group").Value : null, Group_Id = b.Element("Group_Id") != null ? b.Element("Group_Id").Value : null, HasBeenRescheduled = b.Element("HasBeenRescheduled") != null ? Boolean.Parse(b.Element("HasBeenRescheduled").Value) : false }
            ).ToList();
            return matches;
        }

        /// <summary>
        /// Retrieve all already played matches in one league a specific season
        /// </summary>
        /// <param name="league">Name or numerical ID of league</param>
        /// <param name="seasonStartYear">Year that the season started</param>
        /// <returns></returns>
        public List<Match> GetHistoricMatchesByLeagueAndSeason(string league, int seasonStartYear)
        {
            string season = seasonStartYear.ToString().Substring(2) + (seasonStartYear + 1).ToString().Substring(2);
            ProService.FootballDataSoapClient xmlSoccerServicePro = new ProService.FootballDataSoapClient();
            DemoService.FootballDataDemoSoapClient xmlSoccerServiceDemo = new DemoService.FootballDataDemoSoapClient();
            XDocument xDoc = new XDocument();

            if (proMode)
                xDoc = XDocument.Load(new XmlNodeReader(xmlSoccerServicePro.GetHistoricMatchesByLeagueAndSeason(apiKey, league, season)));
            else
                xDoc = XDocument.Load(new XmlNodeReader(xmlSoccerServiceDemo.GetHistoricMatchesByLeagueAndSeason(apiKey, league, season)));
            CheckForErrors(xDoc);
            List<Match> matches = new List<Match>();
            matches = (from b in xDoc.Descendants("Match")
                       select new Match() { Id = Int32.Parse(b.Element("Id").Value), FixtureMatch_Id = b.Element("FixtureMatch_Id") != null ? Int32.Parse(b.Element("FixtureMatch_Id").Value) : 0, Date = DateTime.Parse(b.Element("Date").Value), Round = b.Element("Round") != null ? Int32.Parse(b.Element("Round").Value) : 0, Spectators = b.Element("Spectators") != null ? b.Element("Spectators").Value : null, League = b.Element("League").Value, HomeTeam = b.Element("HomeTeam").Value, HomeTeam_Id = Int32.Parse(b.Element("HomeTeam_Id").Value), HomeGoals = b.Element("HomeGoals") != null ? Int32.Parse(b.Element("HomeGoals").Value) : 0, HomeCorners = b.Element("HomeCorners") != null ? Int32.Parse(b.Element("HomeCorners").Value) : 0, HalfTimeHomeGoals = b.Element("HalfTimeHomeGoals") != null ? Int32.Parse(b.Element("HalfTimeHomeGoals").Value) : 0, HomeShots = b.Element("HomeShots") != null ? Int32.Parse(b.Element("HomeShots").Value) : 0, HomeShotsOnTarget = b.Element("HomeShotsOnTarget") != null ? Int32.Parse(b.Element("HomeShotsOnTarget").Value) : 0, HomeFouls = b.Element("HomeFouls") != null ? Int32.Parse(b.Element("HomeFouls").Value) : 0, AwayTeam = b.Element("AwayTeam").Value, AwayTeam_Id = Int32.Parse(b.Element("AwayTeam_Id").Value), AwayGoals = b.Element("AwayGoals") != null ? Int32.Parse(b.Element("AwayGoals").Value) : 0, AwayCorners = b.Element("AwayCorners") != null ? Int32.Parse(b.Element("AwayCorners").Value) : 0, HalfTimeAwayGoals = b.Element("HalfTimeAwayGoals") != null ? Int32.Parse(b.Element("HalfTimeAwayGoals").Value) : 0, AwayShots = b.Element("AwayShots") != null ? Int32.Parse(b.Element("AwayShots").Value) : 0, AwayShotsOnTarget = b.Element("AwayShotsOnTarget") != null ? Int32.Parse(b.Element("AwayShotsOnTarget").Value) : 0, AwayFouls = b.Element("AwayFouls") != null ? Int32.Parse(b.Element("AwayFouls").Value) : 0, Time = b.Element("Time") != null ? b.Element("Time").Value : null, Location = b.Element("Location") != null ? b.Element("Location").Value : null, HomeTeamYellowCardDetails = b.Element("HomeTeamYellowCardDetails") != null ? b.Element("HomeTeamYellowCardDetails").Value.Split(';') : null, AwayTeamYellowCardDetails = b.Element("AwayTeamYellowCardDetails") != null ? b.Element("AwayTeamYellowCardDetails").Value.Split(';') : null, HomeTeamRedCardDetails = b.Element("HomeTeamRedCardDetails") != null ? b.Element("HomeTeamRedCardDetails").Value.Split(';') : null, AwayTeamRedCardDetails = b.Element("AwayTeamRedCardDetails") != null ? b.Element("AwayTeamRedCardDetails").Value.Split(';') : null, HomeGoalDetails = b.Element("HomeGoalDetails") != null ? b.Element("HomeGoalDetails").Value.Split(';') : null, AwayGoalDetails = b.Element("AwayGoalDetails") != null ? b.Element("AwayGoalDetails").Value.Split(';') : null, HomeLineupDefense = b.Element("HomeLineupDefense") != null ? b.Element("HomeLineupDefense").Value.Split(';') : null, HomeLineupGoalkeeper = b.Element("HomeLineupGoalkeeper") != null ? b.Element("HomeLineupGoalkeeper").Value : null, HomeLineupMidfield = b.Element("HomeLineupMidfield") != null ? b.Element("HomeLineupMidfield").Value.Split(';') : null, HomeLineupForward = b.Element("HomeLineupForward") != null ? b.Element("HomeLineupForward").Value.Split(';') : null, AwayLineupGoalkeeper = b.Element("AwayLineupGoalkeeper") != null ? b.Element("AwayLineupGoalkeeper").Value : null, AwayLineupMidfield = b.Element("AwayLineupMidfield") != null ? b.Element("AwayLineupMidfield").Value.Split(';') : null, AwayLineupForward = b.Element("AwayLineupForward") != null ? b.Element("AwayLineupForward").Value.Split(';') : null, HomeSubDetails = b.Element("HomeSubDetails") != null ? b.Element("HomeSubDetails").Value.Split(';') : null, AwaySubDetails = b.Element("AwaySubDetails") != null ? b.Element("AwaySubDetails").Value.Split(';') : null , HomeTeamFormation = b.Element("HomeTeamFormation") != null ? b.Element("HomeTeamFormation").Value : null, AwayTeamFormation = b.Element("AwayTeamFormation") != null ? b.Element("AwayTeamFormation").Value : null, HomeLineupSubstitutes = b.Element("HomeLineupSubstitutes") != null ? b.Element("HomeLineupSubstitutes").Value.Split(';') : null, AwayLineupSubstitutes = b.Element("AwayLineupSubstitutes") != null ? b.Element("AwayLineupSubstitutes").Value.Split(';') : null, AwayLineupCoach = b.Element("AwayLineupCoach") != null ? b.Element("AwayLineupCoach").Value : null, HomeLineupCoach = b.Element("HomeLineupCoach") != null ? b.Element("HomeLineupCoach").Value : null, AwayLineupDefense = b.Element("AwayLineupDefense") != null ? b.Element("AwayLineupDefense").Value.Split(';') : null, AwayYellowCards = b.Element("AwayYellowCards") != null ? Int32.Parse(b.Element("AwayYellowCards").Value) : 0, HomeYellowCards = b.Element("HomeYellowCards") != null ? Int32.Parse(b.Element("HomeYellowCards").Value) : 0, HomeRedCards = b.Element("HomeRedCards") != null ? Int32.Parse(b.Element("HomeRedCards").Value) : 0, AwayRedCards = b.Element("AwayRedCards") != null ? Int32.Parse(b.Element("AwayRedCards").Value) : 0, Group = b.Element("Group") != null ? b.Element("Group").Value : null, Group_Id = b.Element("Group_Id") != null ? b.Element("Group_Id").Value : null, HasBeenRescheduled = b.Element("HasBeenRescheduled") != null ? Boolean.Parse(b.Element("HasBeenRescheduled").Value) : false }
            ).ToList();
            return matches;
        }

        /// <summary>
        /// Retrieve all matches where a specific team participated within a time interval
        /// </summary>
        /// <param name="dateFrom"></param>
        /// <param name="dateTo"></param>
        /// <param name="teamId">Name or numeric ID of team</param>
        /// <returns></returns>
        public List<Match> GetHistoricMatchesByTeamAndDateInterval(DateTime dateFrom, DateTime dateTo, string teamId)
        {
            ProService.FootballDataSoapClient xmlSoccerServicePro = new ProService.FootballDataSoapClient();
            DemoService.FootballDataDemoSoapClient xmlSoccerServiceDemo = new DemoService.FootballDataDemoSoapClient();
            XDocument xDoc = new XDocument();

            if (proMode)
                xDoc = XDocument.Load(new XmlNodeReader(xmlSoccerServicePro.GetHistoricMatchesByTeamAndDateInterval(apiKey, teamId, convertDateTimeToDateTimeString(dateFrom), convertDateTimeToDateTimeString(dateTo))));
            else
                xDoc = XDocument.Load(new XmlNodeReader(xmlSoccerServiceDemo.GetHistoricMatchesByTeamAndDateInterval(apiKey, teamId, convertDateTimeToDateTimeString(dateFrom), convertDateTimeToDateTimeString(dateTo))));
            CheckForErrors(xDoc);
            List<Match> matches = new List<Match>();
            matches = (from b in xDoc.Descendants("Match")
                       select new Match() { Id = Int32.Parse(b.Element("Id").Value), FixtureMatch_Id = b.Element("FixtureMatch_Id") != null ? Int32.Parse(b.Element("FixtureMatch_Id").Value) : 0, Date = DateTime.Parse(b.Element("Date").Value), Round = b.Element("Round") != null ? Int32.Parse(b.Element("Round").Value) : 0, Spectators = b.Element("Spectators") != null ? b.Element("Spectators").Value : null, League = b.Element("League").Value, HomeTeam = b.Element("HomeTeam").Value, HomeTeam_Id = Int32.Parse(b.Element("HomeTeam_Id").Value), HomeGoals = Int32.Parse(b.Element("HomeGoals").Value), HomeCorners = b.Element("HomeCorners") != null ? Int32.Parse(b.Element("HomeCorners").Value) : 0, HalfTimeHomeGoals = b.Element("HalfTimeHomeGoals") != null ? Int32.Parse(b.Element("HalfTimeHomeGoals").Value) : 0, HomeShots = b.Element("HomeShots") != null ? Int32.Parse(b.Element("HomeShots").Value) : 0, HomeShotsOnTarget = b.Element("HomeShotsOnTarget") != null ? Int32.Parse(b.Element("HomeShotsOnTarget").Value) : 0, HomeFouls = b.Element("HomeFouls") != null ? Int32.Parse(b.Element("HomeFouls").Value) : 0, AwayTeam = b.Element("AwayTeam").Value, AwayTeam_Id = Int32.Parse(b.Element("AwayTeam_Id").Value), AwayGoals = Int32.Parse(b.Element("AwayGoals").Value), AwayCorners = b.Element("AwayCorners") != null ? Int32.Parse(b.Element("AwayCorners").Value) : 0, HalfTimeAwayGoals = b.Element("HalfTimeAwayGoals") != null ? Int32.Parse(b.Element("HalfTimeAwayGoals").Value) : 0, AwayShots = b.Element("AwayShots") != null ? Int32.Parse(b.Element("AwayShots").Value) : 0, AwayShotsOnTarget = b.Element("AwayShotsOnTarget") != null ? Int32.Parse(b.Element("AwayShotsOnTarget").Value) : 0, AwayFouls = b.Element("AwayFouls") != null ? Int32.Parse(b.Element("AwayFouls").Value) : 0, Time = b.Element("Time") != null ? b.Element("Time").Value : null, Location = b.Element("Location") != null ? b.Element("Location").Value : null, HomeTeamYellowCardDetails = b.Element("HomeTeamYellowCardDetails") != null ? b.Element("HomeTeamYellowCardDetails").Value.Split(';') : null, AwayTeamYellowCardDetails = b.Element("AwayTeamYellowCardDetails") != null ? b.Element("AwayTeamYellowCardDetails").Value.Split(';') : null, HomeTeamRedCardDetails = b.Element("HomeTeamRedCardDetails") != null ? b.Element("HomeTeamRedCardDetails").Value.Split(';') : null, AwayTeamRedCardDetails = b.Element("AwayTeamRedCardDetails") != null ? b.Element("AwayTeamRedCardDetails").Value.Split(';') : null, HomeGoalDetails = b.Element("HomeGoalDetails") != null ? b.Element("HomeGoalDetails").Value.Split(';') : null, AwayGoalDetails = b.Element("AwayGoalDetails") != null ? b.Element("AwayGoalDetails").Value.Split(';') : null, HomeLineupDefense = b.Element("HomeLineupDefense") != null ? b.Element("HomeLineupDefense").Value.Split(';') : null, HomeLineupGoalkeeper = b.Element("HomeLineupGoalkeeper") != null ? b.Element("HomeLineupGoalkeeper").Value : null, HomeLineupMidfield = b.Element("HomeLineupMidfield") != null ? b.Element("HomeLineupMidfield").Value.Split(';') : null, HomeLineupForward = b.Element("HomeLineupForward") != null ? b.Element("HomeLineupForward").Value.Split(';') : null, AwayLineupGoalkeeper = b.Element("AwayLineupGoalkeeper") != null ? b.Element("AwayLineupGoalkeeper").Value : null, AwayLineupMidfield = b.Element("AwayLineupMidfield") != null ? b.Element("AwayLineupMidfield").Value.Split(';') : null, AwayLineupForward = b.Element("AwayLineupForward") != null ? b.Element("AwayLineupForward").Value.Split(';') : null, HomeSubDetails = b.Element("HomeSubDetails") != null ? b.Element("HomeSubDetails").Value.Split(';') : null, AwaySubDetails = b.Element("AwaySubDetails") != null ? b.Element("AwaySubDetails").Value.Split(';') : null, HomeTeamFormation = b.Element("HomeTeamFormation") != null ? b.Element("HomeTeamFormation").Value : null, AwayTeamFormation = b.Element("AwayTeamFormation") != null ? b.Element("AwayTeamFormation").Value : null, HomeLineupSubstitutes = b.Element("HomeLineupSubstitutes") != null ? b.Element("HomeLineupSubstitutes").Value.Split(';') : null, AwayLineupSubstitutes = b.Element("AwayLineupSubstitutes") != null ? b.Element("AwayLineupSubstitutes").Value.Split(';') : null, AwayLineupCoach = b.Element("AwayLineupCoach") != null ? b.Element("AwayLineupCoach").Value : null, HomeLineupCoach = b.Element("HomeLineupCoach") != null ? b.Element("HomeLineupCoach").Value : null, AwayLineupDefense = b.Element("AwayLineupDefense") != null ? b.Element("AwayLineupDefense").Value.Split(';') : null, AwayYellowCards = b.Element("AwayYellowCards") != null ? Int32.Parse(b.Element("AwayYellowCards").Value) : 0, HomeYellowCards = b.Element("HomeYellowCards") != null ? Int32.Parse(b.Element("HomeYellowCards").Value) : 0, HomeRedCards = b.Element("HomeRedCards") != null ? Int32.Parse(b.Element("HomeRedCards").Value) : 0, AwayRedCards = b.Element("AwayRedCards") != null ? Int32.Parse(b.Element("AwayRedCards").Value) : 0, Group = b.Element("Group") != null ? b.Element("Group").Value : null, Group_Id = b.Element("Group_Id") != null ? b.Element("Group_Id").Value : null, HasBeenRescheduled = b.Element("HasBeenRescheduled") != null ? Boolean.Parse(b.Element("HasBeenRescheduled").Value) : false }
            ).ToList();
            return matches;
        }

        /// <summary>
        /// Retrieve all matches where two teams played against each other within a time interval
        /// </summary>
        /// <param name="dateFrom"></param>
        /// <param name="dateTo"></param>
        /// <param name="teamId">Name or numeric ID of team1</param>
        /// <param name="team2Id">Name or numeric ID of team2</param>
        /// <returns></returns>
        public List<Match> GetHistoricMatchesByTeamsAndDateInterval(DateTime dateFrom, DateTime dateTo, string teamId, string team2Id)
        {
            ProService.FootballDataSoapClient xmlSoccerServicePro = new ProService.FootballDataSoapClient();
            DemoService.FootballDataDemoSoapClient xmlSoccerServiceDemo = new DemoService.FootballDataDemoSoapClient();
            XDocument xDoc = new XDocument();

            if (proMode)
                xDoc = XDocument.Load(new XmlNodeReader(xmlSoccerServicePro.GetHistoricMatchesByTeamsAndDateInterval(apiKey, teamId, team2Id, convertDateTimeToDateTimeString(dateFrom), convertDateTimeToDateTimeString(dateTo))));
            else
                xDoc = XDocument.Load(new XmlNodeReader(xmlSoccerServiceDemo.GetHistoricMatchesByTeamsAndDateInterval(apiKey, teamId, team2Id, convertDateTimeToDateTimeString(dateFrom), convertDateTimeToDateTimeString(dateTo))));
            CheckForErrors(xDoc);
            List<Match> matches = new List<Match>();
            matches = (from b in xDoc.Descendants("Match")
                       select new Match() { Id = Int32.Parse(b.Element("Id").Value), FixtureMatch_Id = b.Element("FixtureMatch_Id") != null ? Int32.Parse(b.Element("FixtureMatch_Id").Value) : 0, Date = DateTime.Parse(b.Element("Date").Value), Round = b.Element("Round") != null ? Int32.Parse(b.Element("Round").Value) : 0, Spectators = b.Element("Spectators") != null ? b.Element("Spectators").Value : null, League = b.Element("League").Value, HomeTeam = b.Element("HomeTeam").Value, HomeTeam_Id = Int32.Parse(b.Element("HomeTeam_Id").Value), HomeGoals = Int32.Parse(b.Element("HomeGoals").Value), HomeCorners = b.Element("HomeCorners") != null ? Int32.Parse(b.Element("HomeCorners").Value) : 0, HalfTimeHomeGoals = b.Element("HalfTimeHomeGoals") != null ? Int32.Parse(b.Element("HalfTimeHomeGoals").Value) : 0, HomeShots = b.Element("HomeShots") != null ? Int32.Parse(b.Element("HomeShots").Value) : 0, HomeShotsOnTarget = b.Element("HomeShotsOnTarget") != null ? Int32.Parse(b.Element("HomeShotsOnTarget").Value) : 0, HomeFouls = b.Element("HomeFouls") != null ? Int32.Parse(b.Element("HomeFouls").Value) : 0, AwayTeam = b.Element("AwayTeam").Value, AwayTeam_Id = Int32.Parse(b.Element("AwayTeam_Id").Value), AwayGoals = Int32.Parse(b.Element("AwayGoals").Value), AwayCorners = b.Element("AwayCorners") != null ? Int32.Parse(b.Element("AwayCorners").Value) : 0, HalfTimeAwayGoals = b.Element("HalfTimeAwayGoals") != null ? Int32.Parse(b.Element("HalfTimeAwayGoals").Value) : 0, AwayShots = b.Element("AwayShots") != null ? Int32.Parse(b.Element("AwayShots").Value) : 0, AwayShotsOnTarget = b.Element("AwayShotsOnTarget") != null ? Int32.Parse(b.Element("AwayShotsOnTarget").Value) : 0, AwayFouls = b.Element("AwayFouls") != null ? Int32.Parse(b.Element("AwayFouls").Value) : 0, Time = b.Element("Time") != null ? b.Element("Time").Value : null, Location = b.Element("Location") != null ? b.Element("Location").Value : null, HomeTeamYellowCardDetails = b.Element("HomeTeamYellowCardDetails") != null ? b.Element("HomeTeamYellowCardDetails").Value.Split(';') : null, AwayTeamYellowCardDetails = b.Element("AwayTeamYellowCardDetails") != null ? b.Element("AwayTeamYellowCardDetails").Value.Split(';') : null, HomeTeamRedCardDetails = b.Element("HomeTeamRedCardDetails") != null ? b.Element("HomeTeamRedCardDetails").Value.Split(';') : null, AwayTeamRedCardDetails = b.Element("AwayTeamRedCardDetails") != null ? b.Element("AwayTeamRedCardDetails").Value.Split(';') : null, HomeGoalDetails = b.Element("HomeGoalDetails") != null ? b.Element("HomeGoalDetails").Value.Split(';') : null, AwayGoalDetails = b.Element("AwayGoalDetails") != null ? b.Element("AwayGoalDetails").Value.Split(';') : null, HomeLineupDefense = b.Element("HomeLineupDefense") != null ? b.Element("HomeLineupDefense").Value.Split(';') : null, HomeLineupGoalkeeper = b.Element("HomeLineupGoalkeeper") != null ? b.Element("HomeLineupGoalkeeper").Value : null, HomeLineupMidfield = b.Element("HomeLineupMidfield") != null ? b.Element("HomeLineupMidfield").Value.Split(';') : null, HomeLineupForward = b.Element("HomeLineupForward") != null ? b.Element("HomeLineupForward").Value.Split(';') : null, AwayLineupGoalkeeper = b.Element("AwayLineupGoalkeeper") != null ? b.Element("AwayLineupGoalkeeper").Value : null, AwayLineupMidfield = b.Element("AwayLineupMidfield") != null ? b.Element("AwayLineupMidfield").Value.Split(';') : null, AwayLineupForward = b.Element("AwayLineupForward") != null ? b.Element("AwayLineupForward").Value.Split(';') : null, HomeSubDetails = b.Element("HomeSubDetails") != null ? b.Element("HomeSubDetails").Value.Split(';') : null, AwaySubDetails = b.Element("AwaySubDetails") != null ? b.Element("AwaySubDetails").Value.Split(';') : null, HomeTeamFormation = b.Element("HomeTeamFormation") != null ? b.Element("HomeTeamFormation").Value : null, AwayTeamFormation = b.Element("AwayTeamFormation") != null ? b.Element("AwayTeamFormation").Value : null, HomeLineupSubstitutes = b.Element("HomeLineupSubstitutes") != null ? b.Element("HomeLineupSubstitutes").Value.Split(';') : null, AwayLineupSubstitutes = b.Element("AwayLineupSubstitutes") != null ? b.Element("AwayLineupSubstitutes").Value.Split(';') : null, AwayLineupCoach = b.Element("AwayLineupCoach") != null ? b.Element("AwayLineupCoach").Value : null, HomeLineupCoach = b.Element("HomeLineupCoach") != null ? b.Element("HomeLineupCoach").Value : null, AwayLineupDefense = b.Element("AwayLineupDefense") != null ? b.Element("AwayLineupDefense").Value.Split(';') : null, AwayYellowCards = b.Element("AwayYellowCards") != null ? Int32.Parse(b.Element("AwayYellowCards").Value) : 0, HomeYellowCards = b.Element("HomeYellowCards") != null ? Int32.Parse(b.Element("HomeYellowCards").Value) : 0, HomeRedCards = b.Element("HomeRedCards") != null ? Int32.Parse(b.Element("HomeRedCards").Value) : 0, AwayRedCards = b.Element("AwayRedCards") != null ? Int32.Parse(b.Element("AwayRedCards").Value) : 0, Group = b.Element("Group") != null ? b.Element("Group").Value : null, Group_Id = b.Element("Group_Id") != null ? b.Element("Group_Id").Value : null, HasBeenRescheduled = b.Element("HasBeenRescheduled") != null ? Boolean.Parse(b.Element("HasBeenRescheduled").Value) : false }
            ).ToList();
            return matches;
        }

        /// <summary>
        /// Retrieve list of leaguestandings
        /// </summary>
        /// <param name="league">Name or numerical ID of league</param>
        /// <param name="seasonStartYear">The year the season started</param>
        /// <returns>Full standings</returns>
        public List<TeamLeagueStanding> GetLeagueStandingsBySeason(string league, int seasonStartYear)
        {
            string season = seasonStartYear.ToString().Substring(2) + (seasonStartYear + 1).ToString().Substring(2);
            ProService.FootballDataSoapClient xmlSoccerServicePro = new ProService.FootballDataSoapClient();
            DemoService.FootballDataDemoSoapClient xmlSoccerServiceDemo = new DemoService.FootballDataDemoSoapClient();
            XDocument xDoc = new XDocument();

            if (proMode)
                xDoc = XDocument.Load(new XmlNodeReader(xmlSoccerServicePro.GetLeagueStandingsBySeason(apiKey, league, season)));
            else
                xDoc = XDocument.Load(new XmlNodeReader(xmlSoccerServiceDemo.GetLeagueStandingsBySeason(apiKey, league, season)));
            CheckForErrors(xDoc);
            XNamespace ns = "http://xmlsoccer.com/LeagueStanding";
            List<TeamLeagueStanding> standings = new List<TeamLeagueStanding>();
            standings = (from b in xDoc.Descendants(ns + "TeamLeagueStanding")
                         select new TeamLeagueStanding() { Team = b.Element(ns + "Team").Value, Team_Id = Int32.Parse(b.Element(ns + "Team_Id").Value), Played = b.Element(ns + "Played") != null ? Int32.Parse(b.Element(ns + "Played").Value) : 0, PlayedAtHome = b.Element(ns + "PlayedAtHome") != null ? Int32.Parse(b.Element(ns + "PlayedAtHome").Value) : 0, PlayedAway = b.Element(ns + "PlayedAway") != null ? Int32.Parse(b.Element(ns + "PlayedAway").Value) : 0, Won = b.Element(ns + "Won") != null ? Int32.Parse(b.Element(ns + "Won").Value) : 0, Draw = b.Element(ns + "Draw") != null ? Int32.Parse(b.Element(ns + "Draw").Value) : 0, Lost = b.Element(ns + "Lost") != null ? Int32.Parse(b.Element(ns + "Lost").Value) : 0, NumberOfShots = b.Element(ns + "NumberOfShots") != null ? Int32.Parse(b.Element(ns + "NumberOfShots").Value) : 0, YellowCards = b.Element(ns + "YellowCards") != null ? Int32.Parse(b.Element(ns + "YellowCards").Value) : 0, RedCards = b.Element(ns + "RedCards") != null ? Int32.Parse(b.Element(ns + "RedCards").Value) : 0, Goals_For = b.Element(ns + "Goals_For") != null ? Int32.Parse(b.Element(ns + "Goals_For").Value) : 0, Goals_Against = b.Element(ns + "Goals_Against") != null ? Int32.Parse(b.Element(ns + "Goals_Against").Value) : 0, Goal_Difference = b.Element(ns + "Goal_Difference") != null ? Int32.Parse(b.Element(ns + "Goal_Difference").Value) : 0, Points = b.Element(ns + "Points") != null ? Int32.Parse(b.Element(ns + "Points").Value) : 0 }
            ).ToList();
            return standings;
        }

        /// <summary>
        /// Get currently played matches from all leagues
        /// </summary>
        /// <returns>List of all matches currently being followed on xmlsoccer.com</returns>
        public List<Match> GetLiveScore()
        {
            ProService.FootballDataSoapClient xmlSoccerServicePro = new ProService.FootballDataSoapClient();
            DemoService.FootballDataDemoSoapClient xmlSoccerServiceDemo = new DemoService.FootballDataDemoSoapClient();
            XDocument xDoc = new XDocument();

            if (proMode)
                xDoc = XDocument.Load(new XmlNodeReader(xmlSoccerServicePro.GetLiveScore(apiKey)));
            else
                xDoc = XDocument.Load(new XmlNodeReader(xmlSoccerServiceDemo.GetLiveScore(apiKey)));
            CheckForErrors(xDoc);
            List<Match> matches = new List<Match>();
            matches = (from b in xDoc.Descendants("Match")
                       select new Match() { FixtureMatch_Id = Int32.Parse(b.Element("Id").Value), Date = DateTime.Parse(b.Element("Date").Value), Round = b.Element("Round") != null ? Int32.Parse(b.Element("Round").Value) : 0, Spectators = b.Element("Spectators") != null ? b.Element("Spectators").Value : null, League = b.Element("League").Value, HomeTeam = b.Element("HomeTeam").Value, HomeTeam_Id = Int32.Parse(b.Element("HomeTeam_Id").Value), HomeGoals = b.Element("HomeGoals") != null ? Int32.Parse(b.Element("HomeGoals").Value) : 0, HomeCorners = b.Element("HomeCorners") != null ? Int32.Parse(b.Element("HomeCorners").Value) : 0, HalfTimeHomeGoals = b.Element("HalfTimeHomeGoals") != null ? Int32.Parse(b.Element("HalfTimeHomeGoals").Value) : 0, HomeShots = b.Element("HomeShots") != null ? Int32.Parse(b.Element("HomeShots").Value) : 0, HomeShotsOnTarget = b.Element("HomeShotsOnTarget") != null ? Int32.Parse(b.Element("HomeShotsOnTarget").Value) : 0, HomeFouls = b.Element("HomeFouls") != null ? Int32.Parse(b.Element("HomeFouls").Value) : 0, AwayTeam = b.Element("AwayTeam").Value, AwayTeam_Id = Int32.Parse(b.Element("AwayTeam_Id").Value), AwayGoals = b.Element("AwayGoals") != null ? Int32.Parse(b.Element("AwayGoals").Value) : 0, AwayCorners = b.Element("AwayCorners") != null ? Int32.Parse(b.Element("AwayCorners").Value) : 0, HalfTimeAwayGoals = b.Element("HalfTimeAwayGoals") != null ? Int32.Parse(b.Element("HalfTimeAwayGoals").Value) : 0, AwayShots = b.Element("AwayShots") != null ? Int32.Parse(b.Element("AwayShots").Value) : 0, AwayShotsOnTarget = b.Element("AwayShotsOnTarget") != null ? Int32.Parse(b.Element("AwayShotsOnTarget").Value) : 0, AwayFouls = b.Element("AwayFouls") != null ? Int32.Parse(b.Element("AwayFouls").Value) : 0, Time = b.Element("Time") != null ? b.Element("Time").Value : null, Location = b.Element("Location") != null ? b.Element("Location").Value : null, HomeTeamYellowCardDetails = b.Element("HomeTeamYellowCardDetails") != null ? b.Element("HomeTeamYellowCardDetails").Value.Split(';') : null, AwayTeamYellowCardDetails = b.Element("AwayTeamYellowCardDetails") != null ? b.Element("AwayTeamYellowCardDetails").Value.Split(';') : null, HomeTeamRedCardDetails = b.Element("HomeTeamRedCardDetails") != null ? b.Element("HomeTeamRedCardDetails").Value.Split(';') : null, AwayTeamRedCardDetails = b.Element("AwayTeamRedCardDetails") != null ? b.Element("AwayTeamRedCardDetails").Value.Split(';') : null, HomeGoalDetails = b.Element("HomeGoalDetails") != null ? b.Element("HomeGoalDetails").Value.Split(';') : null, AwayGoalDetails = b.Element("AwayGoalDetails") != null ? b.Element("AwayGoalDetails").Value.Split(';') : null, HomeLineupDefense = b.Element("HomeLineupDefense") != null ? b.Element("HomeLineupDefense").Value.Split(';') : null, HomeLineupGoalkeeper = b.Element("HomeLineupGoalkeeper") != null ? b.Element("HomeLineupGoalkeeper").Value : null, HomeLineupMidfield = b.Element("HomeLineupMidfield") != null ? b.Element("HomeLineupMidfield").Value.Split(';') : null, HomeLineupForward = b.Element("HomeLineupForward") != null ? b.Element("HomeLineupForward").Value.Split(';') : null, AwayLineupGoalkeeper = b.Element("AwayLineupGoalkeeper") != null ? b.Element("AwayLineupGoalkeeper").Value : null, AwayLineupDefense = b.Element("AwayLineupDefense") != null ? b.Element("AwayLineupDefense").Value.Split(';') : null, AwayLineupMidfield = b.Element("AwayLineupMidfield") != null ? b.Element("AwayLineupMidfield").Value.Split(';') : null, AwayLineupForward = b.Element("AwayLineupForward") != null ? b.Element("AwayLineupForward").Value.Split(';') : null, HomeSubDetails = b.Element("HomeSubDetails") != null ? b.Element("HomeSubDetails").Value.Split(';') : null, AwaySubDetails = b.Element("AwaySubDetails") != null ? b.Element("AwaySubDetails").Value.Split(';') : null, HomeTeamFormation = b.Element("HomeTeamFormation") != null ? b.Element("HomeTeamFormation").Value : null, AwayTeamFormation = b.Element("AwayTeamFormation") != null ? b.Element("AwayTeamFormation").Value : null, HomeLineupSubstitutes = b.Element("HomeLineupSubstitutes") != null ? b.Element("HomeLineupSubstitutes").Value.Split(';') : null, AwayLineupSubstitutes = b.Element("AwayLineupSubstitutes") != null ? b.Element("AwayLineupSubstitutes").Value.Split(';') : null, AwayLineupCoach = b.Element("AwayLineupCoach") != null ? b.Element("AwayLineupCoach").Value : null, HomeLineupCoach = b.Element("HomeLineupCoach") != null ? b.Element("HomeLineupCoach").Value : null, Group = b.Element("Group") != null ? b.Element("Group").Value : null, Group_Id = b.Element("Group_Id") != null ? b.Element("Group_Id").Value : null, HasBeenRescheduled = b.Element("HasBeenRescheduled") != null ? Boolean.Parse(b.Element("HasBeenRescheduled").Value) : false }
            ).ToList();
            return matches;
        }

        /// <summary>
        ///  Get currently played matches from specific league
        /// </summary>
        /// <param name="league">Name or numeric ID of league</param>
        /// <returns>List of all matches currently being followed on xmlsoccer.com in a specific league</returns>
        public List<Match> GetLiveScoreByLeague(string league)
        {
            ProService.FootballDataSoapClient xmlSoccerServicePro = new ProService.FootballDataSoapClient();
            DemoService.FootballDataDemoSoapClient xmlSoccerServiceDemo = new DemoService.FootballDataDemoSoapClient();
            XDocument xDoc = new XDocument();

            if (proMode)
                xDoc = XDocument.Load(new XmlNodeReader(xmlSoccerServicePro.GetLiveScoreByLeague(apiKey, league)));
            else
                xDoc = XDocument.Load(new XmlNodeReader(xmlSoccerServiceDemo.GetLiveScoreByLeague(apiKey, league)));
            CheckForErrors(xDoc);
            List<Match> matches = new List<Match>();
            matches = (from b in xDoc.Descendants("Match")
                       select new Match() { FixtureMatch_Id = Int32.Parse(b.Element("Id").Value), Date = DateTime.Parse(b.Element("Date").Value), Round = b.Element("Round") != null ? Int32.Parse(b.Element("Round").Value) : 0, Spectators = b.Element("Spectators") != null ? b.Element("Spectators").Value : null, League = b.Element("League").Value, HomeTeam = b.Element("HomeTeam").Value, HomeTeam_Id = Int32.Parse(b.Element("HomeTeam_Id").Value), HomeGoals = b.Element("HomeGoals") != null ? Int32.Parse(b.Element("HomeGoals").Value) : 0, HomeCorners = b.Element("HomeCorners") != null ? Int32.Parse(b.Element("HomeCorners").Value) : 0, HalfTimeHomeGoals = b.Element("HalfTimeHomeGoals") != null ? Int32.Parse(b.Element("HalfTimeHomeGoals").Value) : 0, HomeShots = b.Element("HomeShots") != null ? Int32.Parse(b.Element("HomeShots").Value) : 0, HomeShotsOnTarget = b.Element("HomeShotsOnTarget") != null ? Int32.Parse(b.Element("HomeShotsOnTarget").Value) : 0, HomeFouls = b.Element("HomeFouls") != null ? Int32.Parse(b.Element("HomeFouls").Value) : 0, AwayTeam = b.Element("AwayTeam").Value, AwayTeam_Id = Int32.Parse(b.Element("AwayTeam_Id").Value), AwayGoals = b.Element("AwayGoals") != null ? Int32.Parse(b.Element("AwayGoals").Value) : 0, AwayCorners = b.Element("AwayCorners") != null ? Int32.Parse(b.Element("AwayCorners").Value) : 0, HalfTimeAwayGoals = b.Element("HalfTimeAwayGoals") != null ? Int32.Parse(b.Element("HalfTimeAwayGoals").Value) : 0, AwayShots = b.Element("AwayShots") != null ? Int32.Parse(b.Element("AwayShots").Value) : 0, AwayShotsOnTarget = b.Element("AwayShotsOnTarget") != null ? Int32.Parse(b.Element("AwayShotsOnTarget").Value) : 0, AwayFouls = b.Element("AwayFouls") != null ? Int32.Parse(b.Element("AwayFouls").Value) : 0, Time = b.Element("Time") != null ? b.Element("Time").Value : null, Location = b.Element("Location") != null ? b.Element("Location").Value : null, HomeTeamYellowCardDetails = b.Element("HomeTeamYellowCardDetails") != null ? b.Element("HomeTeamYellowCardDetails").Value.Split(';') : null, AwayTeamYellowCardDetails = b.Element("AwayTeamYellowCardDetails") != null ? b.Element("AwayTeamYellowCardDetails").Value.Split(';') : null, HomeTeamRedCardDetails = b.Element("HomeTeamRedCardDetails") != null ? b.Element("HomeTeamRedCardDetails").Value.Split(';') : null, AwayTeamRedCardDetails = b.Element("AwayTeamRedCardDetails") != null ? b.Element("AwayTeamRedCardDetails").Value.Split(';') : null, HomeGoalDetails = b.Element("HomeGoalDetails") != null ? b.Element("HomeGoalDetails").Value.Split(';') : null, AwayGoalDetails = b.Element("AwayGoalDetails") != null ? b.Element("AwayGoalDetails").Value.Split(';') : null, HomeLineupDefense = b.Element("HomeLineupDefense") != null ? b.Element("HomeLineupDefense").Value.Split(';') : null, HomeLineupGoalkeeper = b.Element("HomeLineupGoalkeeper") != null ? b.Element("HomeLineupGoalkeeper").Value : null, HomeLineupMidfield = b.Element("HomeLineupMidfield") != null ? b.Element("HomeLineupMidfield").Value.Split(';') : null, HomeLineupForward = b.Element("HomeLineupForward") != null ? b.Element("HomeLineupForward").Value.Split(';') : null, AwayLineupGoalkeeper = b.Element("AwayLineupGoalkeeper") != null ? b.Element("AwayLineupGoalkeeper").Value : null, AwayLineupDefense = b.Element("AwayLineupDefense") != null ? b.Element("AwayLineupDefense").Value.Split(';') : null, AwayLineupMidfield = b.Element("AwayLineupMidfield") != null ? b.Element("AwayLineupMidfield").Value.Split(';') : null, AwayLineupForward = b.Element("AwayLineupForward") != null ? b.Element("AwayLineupForward").Value.Split(';') : null, HomeSubDetails = b.Element("HomeSubDetails") != null ? b.Element("HomeSubDetails").Value.Split(';') : null, AwaySubDetails = b.Element("AwaySubDetails") != null ? b.Element("AwaySubDetails").Value.Split(';') : null, HomeTeamFormation = b.Element("HomeTeamFormation") != null ? b.Element("HomeTeamFormation").Value : null, AwayTeamFormation = b.Element("AwayTeamFormation") != null ? b.Element("AwayTeamFormation").Value : null, HomeLineupSubstitutes = b.Element("HomeLineupSubstitutes") != null ? b.Element("HomeLineupSubstitutes").Value.Split(';') : null, AwayLineupSubstitutes = b.Element("AwayLineupSubstitutes") != null ? b.Element("AwayLineupSubstitutes").Value.Split(';') : null, AwayLineupCoach = b.Element("AwayLineupCoach") != null ? b.Element("AwayLineupCoach").Value : null, HomeLineupCoach = b.Element("HomeLineupCoach") != null ? b.Element("HomeLineupCoach").Value : null, Group = b.Element("Group") != null ? b.Element("Group").Value : null, Group_Id = b.Element("Group_Id") != null ? b.Element("Group_Id").Value : null }
            ).ToList();
            return matches;
        }

        /// <summary>
        /// Gets list of topscorers for the requested league and season
        /// </summary>
        /// <param name="league">Name or numeric ID of league</param>
        /// <param name="seasonStartYear">Year that the season started</param>
        /// <returns>List of topscorers</returns>
        public List<Topscorer> GetTopScorersByLeagueAndSeason(string league, int seasonStartYear)
        {
            string season = seasonStartYear.ToString().Substring(2) + (seasonStartYear + 1).ToString().Substring(2);
            ProService.FootballDataSoapClient xmlSoccerServicePro = new ProService.FootballDataSoapClient();
            DemoService.FootballDataDemoSoapClient xmlSoccerServiceDemo = new DemoService.FootballDataDemoSoapClient();
            XDocument xDoc = new XDocument();

            if (proMode)
                xDoc = XDocument.Load(new XmlNodeReader(xmlSoccerServicePro.GetTopScorersByLeagueAndSeason(apiKey, league, season)));
            else
                xDoc = XDocument.Load(new XmlNodeReader(xmlSoccerServiceDemo.GetTopScorersByLeagueAndSeason(apiKey, league, season)));
            CheckForErrors(xDoc);
            List<Topscorer> topScorers = new List<Topscorer>();
            topScorers = (from b in xDoc.Descendants("Topscorer")
                          select new Topscorer() { TeamName = b.Element("TeamName").Value, Nationality = b.Element("Nationality").Value, Name = b.Element("Name").Value, Rank = Int32.Parse(b.Element("Rank").Value), Team_Id = b.Element("Team_Id") != null ? Int32.Parse(b.Element("Team_Id").Value) : 0, Goals = b.Element("Goals") != null ? Int32.Parse(b.Element("Goals").Value) : 0, FirstScorer = b.Element("FirstScorer") != null ? Int32.Parse(b.Element("FirstScorer").Value) : 0, Penalties = b.Element("Penalties") != null ? Int32.Parse(b.Element("Penalties").Value) : 0, MissedPenalties = b.Element("MissedPenalties") != null ? Int32.Parse(b.Element("MissedPenalties").Value) : 0 }
            ).ToList();
            return topScorers;
        }

        /// <summary>
        /// Retrieve a specific team
        /// </summary>
        /// <param name="teamName">Either full teamname or numerical ID</param>
        /// <returns>Team information</returns>
        public Team GetTeam(string teamName)
        {
            ProService.FootballDataSoapClient xmlSoccerServicePro = new ProService.FootballDataSoapClient();
            DemoService.FootballDataDemoSoapClient xmlSoccerServiceDemo = new DemoService.FootballDataDemoSoapClient();
            XDocument xDoc = new XDocument();

            if (proMode)
                xDoc = XDocument.Load(new XmlNodeReader(xmlSoccerServicePro.GetTeam(apiKey, teamName)));
            else
                xDoc = XDocument.Load(new XmlNodeReader(xmlSoccerServiceDemo.GetTeam(apiKey, teamName)));
            CheckForErrors(xDoc);
            Team team = new Team();
            team = (from b in xDoc.Descendants("Team")
                    select new Team() { Team_Id = Int32.Parse(b.Element("Id").Value), Name = b.Element("Name").Value, WIKILink = b.Element("WikiPageUrl") != null ? b.Element("WikiPageUrl").Value : null, Country = b.Element("Country") != null ? b.Element("Country").Value : null, Stadium = b.Element("Stadium") != null ? b.Element("Stadium").Value : null, HomePageURL = b.Element("Website") != null ? b.Element("Website").Value : null }
            ).FirstOrDefault();
            return team;
        }


        /// <summary>
        /// Retrieve all teams
        /// </summary>
        /// <returns>All teams</returns>
        public List<Team> GetAllTeams()
        {
            ProService.FootballDataSoapClient xmlSoccerServicePro = new ProService.FootballDataSoapClient();
            DemoService.FootballDataDemoSoapClient xmlSoccerServiceDemo = new DemoService.FootballDataDemoSoapClient();
            XDocument xDoc = new XDocument();

            if (proMode)
                xDoc = XDocument.Load(new XmlNodeReader(xmlSoccerServicePro.GetAllTeams(apiKey)));
            else
                xDoc = XDocument.Load(new XmlNodeReader(xmlSoccerServiceDemo.GetAllTeams(apiKey)));
            CheckForErrors(xDoc);
            List<Team> teams = new List<Team>();
            teams = (from b in xDoc.Descendants("Team")
                     select new Team() { Team_Id = Int32.Parse(b.Element("Team_Id").Value), Name = b.Element("Name").Value, WIKILink = b.Element("WIKILink") != null ? b.Element("WIKILink").Value : null, Country = b.Element("Country") != null ? b.Element("Country").Value : null, Stadium = b.Element("Stadium") != null ? b.Element("Stadium").Value : null, HomePageURL = b.Element("HomePageURL") != null ? b.Element("HomePageURL").Value : null }
            ).ToList();
            return teams;
        }

        /// <summary>
        /// Retrieve all teams for a particular league and season
        /// </summary>
        /// <returns>All teams</returns>
        public List<Team> GetAllTeamsByLeagueAndSeason(string league, int seasonStartYear)
        {
            string season = seasonStartYear.ToString().Substring(2) + (seasonStartYear + 1).ToString().Substring(2);
            ProService.FootballDataSoapClient xmlSoccerServicePro = new ProService.FootballDataSoapClient();
            DemoService.FootballDataDemoSoapClient xmlSoccerServiceDemo = new DemoService.FootballDataDemoSoapClient();
            XDocument xDoc = new XDocument();

            if (proMode)
                xDoc = XDocument.Load(new XmlNodeReader(xmlSoccerServicePro.GetAllTeamsByLeagueAndSeason(apiKey, league, season)));
            else
                xDoc = XDocument.Load(new XmlNodeReader(xmlSoccerServiceDemo.GetAllTeamsByLeagueAndSeason(apiKey, league, season)));
            CheckForErrors(xDoc);

            XNamespace ns = "http://xmlsoccer.com/Team";
            List<Team> teams = new List<Team>();
            teams = (from b in xDoc.Descendants(ns + "Team")
                     select new Team()
                     {
                         Team_Id = Int32.Parse(b.Element(ns + "Team_Id").Value),
                         Name = b.Element(ns + "Name").Value,
                         WIKILink = b.Element(ns + "WIKILink") != null ? b.Element(ns + "WIKILink").Value : null,
                         Country = b.Element(ns + "Country") != null ? b.Element(ns + "Country").Value : null,
                         Stadium = b.Element(ns + "Stadium") != null ? b.Element(ns + "Stadium").Value : null,
                         HomePageURL = b.Element(ns + "HomePageURL") != null ? b.Element(ns + "HomePageURL").Value : null
                     }
            ).ToList();
            return teams;
        }

        /// <summary>
        /// Retrieve all leagues
        /// </summary>
        /// <returns>All leagues</returns>
        public List<League> GetAllLeagues()
        {
            ProService.FootballDataSoapClient xmlSoccerServicePro = new ProService.FootballDataSoapClient();
            DemoService.FootballDataDemoSoapClient xmlSoccerServiceDemo = new DemoService.FootballDataDemoSoapClient();
            XDocument xDoc = new XDocument();

            if (proMode)
                xDoc = XDocument.Load(new XmlNodeReader(xmlSoccerServicePro.GetAllLeagues(apiKey)));
            else
                xDoc = XDocument.Load(new XmlNodeReader(xmlSoccerServiceDemo.GetAllLeagues(apiKey)));
            CheckForErrors(xDoc);
            List<League> leagues = new List<League>();
            leagues = (from b in xDoc.Descendants("League")
                       select new League() { Id = Int32.Parse(b.Element("Id").Value), Name = b.Element("Name").Value, Country = b.Element("Country") != null ? b.Element("Country").Value : null, Historical_Data = b.Element("Historical_Data") != null ? b.Element("Historical_Data").Value : null, Fixtures = b.Element("Fixtures") != null ? b.Element("Fixtures").Value.Contains("Yes") : false, Livescore = b.Element("Livescore") != null ? b.Element("Livescore").Value.Contains("Yes") : false, LatestMatchResult = b.Element("LatestMatchResult") != null ? DateTime.Parse(b.Element("LatestMatchResult").Value) : DateTime.Now, NumberOfMatches = b.Element("NumberOfMatches") != null ? Int32.Parse(b.Element("NumberOfMatches").Value) : 0 }
            ).ToList();
            return leagues;
        }

        /// <summary>
        /// Gets market information (odds) from various bookmakers, deprecated - use GetAllOddsByFixtureMatch
        /// </summary>
        /// <param name="match">The match you want to retrieve odds from. Keep in mind odds normally aren't released more than a week prior kickoff</param>
        /// <returns>List of Odds</returns>
        public List<Odds> GetOddsByFixtureMatch(Match match)
        {
            if (match.FixtureMatch_Id != 0)
            {
                ProService.FootballDataSoapClient xmlSoccerServicePro = new ProService.FootballDataSoapClient();
                DemoService.FootballDataDemoSoapClient xmlSoccerServiceDemo = new DemoService.FootballDataDemoSoapClient();
                XDocument xDoc = new XDocument();

                if (proMode)
                    xDoc = XDocument.Load(new XmlNodeReader(xmlSoccerServicePro.GetOddsByFixtureMatchId2(apiKey, match.FixtureMatch_Id.ToString())));
                else
                    xDoc = XDocument.Load(new XmlNodeReader(xmlSoccerServiceDemo.GetOddsByFixtureMatchId2(apiKey, match.FixtureMatch_Id.ToString())));
                CheckForErrors(xDoc);
                List<Odds> odds = new List<Odds>();
                odds = (from b in xDoc.Descendants("Bookmaker")
                        select new Odds() { Name = b.Element("Name").Value, Type = "1X2", URL = b.Element("URL") != null ? b.Element("URL").Value : null, Home = b.Element("Home") != null ? double.Parse(b.Element("Home").Value) : 0, Draw = b.Element("Draw") != null ? double.Parse(b.Element("Draw").Value) : 0, Away = b.Element("Away") != null ? double.Parse(b.Element("Away").Value) : 0 }
                ).ToList();
                return odds;
            }
            else
                return null;
        }

        /// <summary>
        /// Gets market information (odds) from various bookmakers
        /// </summary>
        /// <param name="match">The match you want to retrieve odds from. Keep in mind odds normally aren't released more than a week prior kickoff</param>
        /// <returns>List of Odds</returns>
        public List<Odds> GetAllOddsByFixtureMatch(Match match)
        {
            if (match.FixtureMatch_Id != 0)
            {
                ProService.FootballDataSoapClient xmlSoccerServicePro = new ProService.FootballDataSoapClient();
                DemoService.FootballDataDemoSoapClient xmlSoccerServiceDemo = new DemoService.FootballDataDemoSoapClient();
                XDocument xDoc = new XDocument();

                if (proMode)
                    xDoc = XDocument.Load(new XmlNodeReader(xmlSoccerServicePro.GetAllOddsByFixtureMatchId(apiKey, match.FixtureMatch_Id.Value)));
                else
                    xDoc = XDocument.Load(new XmlNodeReader(xmlSoccerServiceDemo.GetAllOddsByFixtureMatchId(apiKey, match.FixtureMatch_Id.Value)));
                CheckForErrors(xDoc);
                List<Odds> odds = new List<Odds>();
                odds = (from b in xDoc.Descendants("Odds")
                        select new Odds() { Name = b.Element("Bookmaker").Value, URL = null, Type = b.Element("Type") != null ? b.Element("Type").Value : null, Home = b.Element("Home") != null ? double.Parse(b.Element("Home").Value) : 0, Draw = b.Element("Draw") != null ? double.Parse(b.Element("Draw").Value) : 0, Away = b.Element("Away") != null ? double.Parse(b.Element("Away").Value) : 0 }
                ).ToList();
                return odds;
            }
            else
                return null;
        }

        /// <summary>
        /// Gets market information (odds) from various bookmakers
        /// </summary>
        /// <param name="match">The match you want to retrieve odds from. Keep in mind odds normally aren't released more than a week prior kickoff</param>
        /// <returns>List of Odds</returns>
        public List<Odds> GetAllOddsByFixtureMatch(int match_id)
        {
                ProService.FootballDataSoapClient xmlSoccerServicePro = new ProService.FootballDataSoapClient();
                DemoService.FootballDataDemoSoapClient xmlSoccerServiceDemo = new DemoService.FootballDataDemoSoapClient();
                XDocument xDoc = new XDocument();

                if (proMode)
                    xDoc = XDocument.Load(new XmlNodeReader(xmlSoccerServicePro.GetAllOddsByFixtureMatchId(apiKey, match_id)));
                else
                    xDoc = XDocument.Load(new XmlNodeReader(xmlSoccerServiceDemo.GetAllOddsByFixtureMatchId(apiKey, match_id)));
                CheckForErrors(xDoc);
                List<Odds> odds = new List<Odds>();
                odds = (from b in xDoc.Descendants("Odds")
                        select new Odds() { Name = b.Element("Bookmaker").Value, URL = null, Type = b.Element("Type") != null ? b.Element("Type").Value : null, Home = b.Element("Home") != null ? double.Parse(b.Element("Home").Value) : 0, Draw = b.Element("Draw") != null ? double.Parse(b.Element("Draw").Value) : 0, Away = b.Element("Away") != null ? double.Parse(b.Element("Away").Value) : 0 }
                ).ToList();
                return odds;
        }

        /// <summary>
        /// Gets market information (odds) from various bookmakers, deprecated - use GetAllOddsByFixtureMatch
        /// </summary>
        /// <param name="fixtureMatch_Id">The fixtureMatch_Id of the match</param>
        /// <returns>List of Odds</returns>
        public List<Odds> GetOddsByFixtureMatch(int fixtureMatch_Id)
        {
            if (fixtureMatch_Id != 0)
            {
                ProService.FootballDataSoapClient xmlSoccerServicePro = new ProService.FootballDataSoapClient();
                DemoService.FootballDataDemoSoapClient xmlSoccerServiceDemo = new DemoService.FootballDataDemoSoapClient();
                XDocument xDoc = new XDocument();

                if (proMode)
                    xDoc = XDocument.Load(new XmlNodeReader(xmlSoccerServicePro.GetOddsByFixtureMatchId2(apiKey, fixtureMatch_Id.ToString())));
                else
                    xDoc = XDocument.Load(new XmlNodeReader(xmlSoccerServiceDemo.GetOddsByFixtureMatchId2(apiKey, fixtureMatch_Id.ToString())));
                CheckForErrors(xDoc);
                List<Odds> odds = new List<Odds>();
                odds = (from b in xDoc.Descendants("Bookmaker")
                        select new Odds() { Name = b.Element("Name").Value, URL = b.Element("URL") != null ? b.Element("URL").Value : null, Home = b.Element("Home") != null ? double.Parse(b.Element("Home").Value.Replace(".", ",")) : 0, Draw = b.Element("Draw") != null ? double.Parse(b.Element("Draw").Value.Replace(".", ",")) : 0, Away = b.Element("Away") != null ? double.Parse(b.Element("Away").Value.Replace(".", ",")) : 0 }
                ).ToList();
                return odds;
            }
            else
                return null;
        }


        /// <summary>
        /// Gets market information (odds) from current and next matches by league
        /// </summary>
        /// <param name="league">The fixtureMatch_Id of the match</param>
        /// <returns>List of Odds</returns>
        public List<MatchOdds> GetNextMatchOddsByLeague(string league)
        {
                ProService.FootballDataSoapClient xmlSoccerServicePro = new ProService.FootballDataSoapClient();
                DemoService.FootballDataDemoSoapClient xmlSoccerServiceDemo = new DemoService.FootballDataDemoSoapClient();
                XDocument xDoc = new XDocument();

                if (proMode)
                    xDoc = XDocument.Load(new XmlNodeReader(xmlSoccerServicePro.GetNextMatchOddsByLeague(apiKey, league)));
                else
                    xDoc = XDocument.Load(new XmlNodeReader(xmlSoccerServiceDemo.GetNextMatchOddsByLeague(apiKey, league)));
                CheckForErrors(xDoc);
                List<MatchOdds> matchOdds = new List<MatchOdds>();
                matchOdds = 
                    (from b in xDoc.Descendants("Odds")
                     select new MatchOdds()
                     {
                         FixtureMatch_Id = Int32.Parse(b.Element("FixtureMatch_Id").Value),
                         Odds =  b.Elements("Bookmaker")
                         .Select(n =>
                         new Odds()
                         {
                             Name = n.Element("Name").Value,
                             URL = n.Element("URL") != null ? n.Element("URL").Value : null,
                             Home = n.Element("Home") != null ? double.Parse(n.Element("Home").Value.Replace(".", ",")) : 0,
                             Draw = n.Element("Draw") != null ? double.Parse(n.Element("Draw").Value.Replace(".", ",")) : 0,
                             Away = n.Element("Away") != null ? double.Parse(n.Element("Away").Value.Replace(".", ",")) : 0,
                         }).ToList(),
                     }
                ).ToList();
                return matchOdds;            
        }

        /// <summary>
        /// Gets playerdata
        /// </summary>
        /// <param name="playerId">The id (unique) of the player</param>
        /// <returns>Player details</returns>
        public Player GetPlayerById(int playerId)
        {
            if (playerId != 0)
            {
                ProService.FootballDataSoapClient xmlSoccerServicePro = new ProService.FootballDataSoapClient();
                DemoService.FootballDataDemoSoapClient xmlSoccerServiceDemo = new DemoService.FootballDataDemoSoapClient();
                XDocument xDoc = new XDocument();

                if (proMode)
                    xDoc = XDocument.Load(new XmlNodeReader(xmlSoccerServicePro.GetPlayerById(apiKey, playerId)));
                else
                    xDoc = XDocument.Load(new XmlNodeReader(xmlSoccerServiceDemo.GetPlayerById(apiKey, playerId)));
                CheckForErrors(xDoc);
                Player player = new Player();
                player = (from b in xDoc.Descendants("Player")
                          select new Player() { Name = b.Element("Name").Value, DateOfBirth = b.Element("DateOfBirth") != null ? DateTime.Parse(b.Element("DateOfBirth").Value) : new DateTime(), DateOfSigning = b.Element("DateOfSigning") != null ? DateTime.Parse(b.Element("DateOfSigning").Value) : new DateTime(), Height = b.Element("Height") != null ? double.Parse(b.Element("Height").Value.Replace(".", ",")) : 0, Id = b.Element("Id") != null ? Int32.Parse(b.Element("Id").Value) : 0, Nationality = b.Element("Nationality") != null ? b.Element("Nationality").Value : null, PlayerNumber = b.Element("PlayerNumber") != null ? Int32.Parse(b.Element("PlayerNumber").Value) : 0, Position = b.Element("Position") != null ? b.Element("Position").Value : null, Signing = b.Element("Signing") != null ? b.Element("Signing").Value : null, Team_Id = b.Element("Team_Id") != null ? Int32.Parse(b.Element("Team_Id").Value) : 0, Weight = b.Element("Weight") != null ? double.Parse(b.Element("Weight").Value.Replace(".", ",")) : 0 }
                ).FirstOrDefault();
                return player;
            }
            else
                return null;
        }

        /// <summary>
        /// Gets playerdata for all players from a specific team
        /// </summary>
        /// <param name="teamId">The name or numeric Id of team</param>
        /// <returns>List of players currently signed by the specific team</returns>
        public List<Player> GetPlayerById(string teamId)
        {
            if (!String.IsNullOrEmpty(teamId))
            {
                ProService.FootballDataSoapClient xmlSoccerServicePro = new ProService.FootballDataSoapClient();
                DemoService.FootballDataDemoSoapClient xmlSoccerServiceDemo = new DemoService.FootballDataDemoSoapClient();
                XDocument xDoc = new XDocument();

                if (proMode)
                    xDoc = XDocument.Load(new XmlNodeReader(xmlSoccerServicePro.GetPlayersByTeam(apiKey, teamId)));
                else
                    xDoc = XDocument.Load(new XmlNodeReader(xmlSoccerServiceDemo.GetPlayersByTeam(apiKey, teamId)));
                CheckForErrors(xDoc);
                List<Player> players = new List<Player>();
                players = (from b in xDoc.Descendants("Player")
                          select new Player() { Name = b.Element("Name").Value, DateOfBirth = b.Element("DateOfBirth") != null ? DateTime.Parse(b.Element("DateOfBirth").Value) : new DateTime(), DateOfSigning = b.Element("DateOfSigning") != null ? DateTime.Parse(b.Element("DateOfSigning").Value) : new DateTime(), Height = b.Element("Height") != null ? double.Parse(b.Element("Height").Value.Replace(".", ",")) : 0, Id = b.Element("Id") != null ? Int32.Parse(b.Element("Id").Value) : 0, Nationality = b.Element("Nationality") != null ? b.Element("Nationality").Value : null, PlayerNumber = b.Element("PlayerNumber") != null ? Int32.Parse(b.Element("PlayerNumber").Value) : 0, Position = b.Element("Position") != null ? b.Element("Position").Value : null, Signing = b.Element("Signing") != null ? b.Element("Signing").Value : null, Team_Id = b.Element("Team_Id") != null ? Int32.Parse(b.Element("Team_Id").Value) : 0, Weight = b.Element("Weight") != null ? double.Parse(b.Element("Weight").Value.Replace(".", ",")) : 0 }
                ).ToList();
                return players;
            }
            else
                return null;
        }

        /// <summary>
        /// Gets Groups for specific league - can only be used in pro mode as demo league does not contain groups
        /// </summary>
        /// <param name="league">The name or numeric Id of league. League must be a Cup</param>
        /// <param name="seasonStartYear">The year the first match in this season was played.</param>
        /// <returns>List of groups in specific league</returns>
        public List<Group> GetAllGroupsByLeagueAndSeason(string league, int seasonStartYear)
        {
            string season = seasonStartYear.ToString().Substring(2) + (seasonStartYear + 1).ToString().Substring(2);
            if (!String.IsNullOrEmpty(league))
            {
                ProService.FootballDataSoapClient xmlSoccerServicePro = new ProService.FootballDataSoapClient();
                DemoService.FootballDataDemoSoapClient xmlSoccerServiceDemo = new DemoService.FootballDataDemoSoapClient();
                XDocument xDoc = new XDocument();

                if (proMode)
                    xDoc = XDocument.Load(new XmlNodeReader(xmlSoccerServicePro.GetAllGroupsByLeagueAndSeason(apiKey, league, season)));
                else
                    return null;
                CheckForErrors(xDoc);
                List<Group> groups = new List<Group>();
                groups = (from b in xDoc.Descendants("Group")
                          select new Group() { Name = b.Element("Name").Value, Id = b.Element("Id") != null ? Int32.Parse(b.Element("Id").Value) : 0, Season = b.Element("Season") != null ? b.Element("Season").Value : null, League_Id = b.Element("League_Id") != null ? Int32.Parse(b.Element("League_Id").Value) : 0 }
                ).ToList();
                return groups;
            }
            else
                return null;
        }

        /// <summary>
        /// Retrieve list of leaguestandings for given group - only applicable using the pro-mode (Demo league does not contain groups)
        /// </summary>
        /// <param name="group_Id">Numeric Group ID</param>
        /// <returns>Full Group standings</returns>
        public List<TeamLeagueStanding> GetCupStandingsByGroupId(int group_Id)
        {
            
            ProService.FootballDataSoapClient xmlSoccerServicePro = new ProService.FootballDataSoapClient();            
            XDocument xDoc = new XDocument();

            if (proMode)
                xDoc = XDocument.Load(new XmlNodeReader(xmlSoccerServicePro.GetCupStandingsByGroupId(apiKey, group_Id)));
            else
                return null;
            CheckForErrors(xDoc);
            XNamespace ns = "http://xmlsoccer.com/TeamCupStanding";
            List<TeamLeagueStanding> standings = new List<TeamLeagueStanding>();
            standings = (from b in xDoc.Descendants(ns + "TeamCupStanding")
                         select new TeamLeagueStanding() { Team = b.Element(ns + "Team").Value, Team_Id = Int32.Parse(b.Element(ns + "Team_Id").Value), Played = b.Element(ns + "Played") != null ? Int32.Parse(b.Element(ns + "Played").Value) : 0, PlayedAtHome = b.Element(ns + "PlayedAtHome") != null ? Int32.Parse(b.Element(ns + "PlayedAtHome").Value) : 0, PlayedAway = b.Element(ns + "PlayedAway") != null ? Int32.Parse(b.Element(ns + "PlayedAway").Value) : 0, Won = b.Element(ns + "Won") != null ? Int32.Parse(b.Element(ns + "Won").Value) : 0, Draw = b.Element(ns + "Draw") != null ? Int32.Parse(b.Element(ns + "Draw").Value) : 0, Lost = b.Element(ns + "Lost") != null ? Int32.Parse(b.Element(ns + "Lost").Value) : 0, NumberOfShots = b.Element(ns + "NumberOfShots") != null ? Int32.Parse(b.Element(ns + "NumberOfShots").Value) : 0, YellowCards = b.Element(ns + "YellowCards") != null ? Int32.Parse(b.Element(ns + "YellowCards").Value) : 0, RedCards = b.Element(ns + "RedCards") != null ? Int32.Parse(b.Element(ns + "RedCards").Value) : 0, Goals_For = b.Element(ns + "Goals_For") != null ? Int32.Parse(b.Element(ns + "Goals_For").Value) : 0, Goals_Against = b.Element(ns + "Goals_Against") != null ? Int32.Parse(b.Element(ns + "Goals_Against").Value) : 0, Goal_Difference = b.Element(ns + "Goal_Difference") != null ? Int32.Parse(b.Element(ns + "Goal_Difference").Value) : 0, Points = b.Element(ns + "Points") != null ? Int32.Parse(b.Element(ns + "Points").Value) : 0, Group_Id = b.Element(ns + "Group_Id") != null ? Int32.Parse(b.Element(ns + "Group_Id").Value) : 0, Group = b.Element(ns + "Group") != null ? b.Element(ns + "Group").Value : null }
            ).ToList();
            return standings;
        }

        protected void CheckForErrors(XDocument xDoc)
        {
            if (xDoc.Root.Value.Contains("To avoid misuse of the service, you are not allowed to request data again (for this specific method) so soon."))
                throw new TooFrequentRequestException(xDoc.Root.Value);
            if (xDoc.Root.Value.Contains("We were unable to verify your API-key with our database."))
                throw new InvalidAPIKeyException(xDoc.Root.Value);
            if (xDoc.Root.Value.Contains("Error: The ID ("))
                throw new InvalidIDException(xDoc.Root.Value);            
        }




        /// <summary>
        /// Get account information - returns blank until the first request.
        /// </summary>
        /// <returns>Latest received account information</returns>
        //public string GetAccountInformation()
        //{
        //    return this.accountInformation;
        //}







        private string convertDateTimeToDateTimeString(DateTime date)
        {
            return date.Year.ToString() + "-" + date.Month.ToString() + "-" + date.Day.ToString();
        }

    }

    
}
