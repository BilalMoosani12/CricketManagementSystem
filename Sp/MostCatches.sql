﻿Alter PROCEDURE [usp_GetMostCatches]
@paramTeamId AS INT,
@paramSeason As Int,
@paramOvers As Int,
@paramMatchType As Int,
@paramTournamentId As Int,
@paramMatchseriesId As Int,
@paramPlayerRoleId As Int,
@paramUserId as int
AS
BEGIN
	SELECT  top 10
			count (PlayerScores.MatchId) as 'TotalMatch',
			sum (Catches) as 'MostCatches',
			Players.Player_Name AS 'PlayerName'
			
	
	FROM PlayerScores
	Inner join Players ON PlayerScores.PlayerId = Players.PlayerId
	Inner join Teams ON Players.TeamId = Teams.TeamId
	Inner join Matches ON PlayerScores.MatchId = Matches.MatchId
	left join Tournaments On Matches.TournamentId = Tournaments.TournamentId
	left join MatchSeries On Matches.MatchSeriesId = MatchSeries.MatchSeriesId
	left join PlayerRole On Players.PlayerRoleId = PlayerRole.PlayerRoleId
	
	
	
	WHERE (@paramTeamId Is NUll or Players.TeamId = @paramTeamId or Matches.OppponentTeamId = @paramTeamId ) And 
		  (@paramSeason IS NUll OR Matches.Season = @paramSeason)	And
		  (@paramOvers IS NUll OR Matches.MatchOvers = @paramOvers)	And 
		  (@paramMatchType IS NULL OR Matches.MatchTypeId = @paramMatchType) And 
		  (@paramMatchseriesId IS NULL OR MatchSeries.MatchSeriesId = @paramMatchseriesId) And 
		  (@paramMatchseriesId IS NULL OR MatchSeries.MatchSeriesId = @paramMatchseriesId) And 
		  (@paramPlayerRoleId IS NUll OR PlayerRole.PlayerRoleId = @paramPlayerRoleId) And
		  (@paramUserId IS NUll OR Matches.UserId = @paramUserId) And
		  (Players.IsDeactivated != 1) and 
		  (Players.IsGuestorRegistered != 'Guest' or Players.IsGuestorRegistered is null)
	
	
	GROUP BY PlayerScores.PlayerId,
			Players.Player_Name,
			PlayerRole.Name,
			Players.TeamId
		--	PlayerScores.Bat_Runs

	order by sum(Catches) desc ;
END
go