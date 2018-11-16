﻿Alter procedure [usp_HomeScreen]
@paramUserId AS INT
AS
begin
	SELECT *
	FROM
	(
		SELECT COUNT(1) as 'Tournaments'
		FROM Tournaments
		WHERE (@paramUserId Is NUll or Tournaments.UserId = @paramUserId)
	) AS Tournaments,
	(
		SELECT	COUNT(1) as 'Players'
		FROM Players	
		inner join Teams on  Players.TeamId = Teams.TeamId
		inner join Matches on  Teams.TeamId = Matches.OppponentTeamId
		inner join Matches homeTeamMatches on  Teams.TeamId = homeTeamMatches.HomeTeamId
		inner join Tournaments on  Matches.TournamentId = Tournaments.TournamentId
		where(@paramUserId Is NUll or Tournaments.UserId = @paramUserId)
	) AS players,
		(
		SELECT	COUNT(1) as 'Teams'
		FROM Teams
	) AS Teams,
		(
		SELECT	COUNT(1) as 'Records'
		FROM PlayerScores
	) AS PlayerScores,
		(
		SELECT	COUNT(1) as 'Matches'
		FROM Matches
	) AS Matches,
	(
		SELECT	COUNT(1) as 'Series'
		FROM MatchSeries
	) AS Series,

		(
		SELECT	top 1
				homeTeam.Team_Name as 'HomeTeam',
				Teams.Team_Name as 'OppponentTeam',
				homeTeamScore.TotalScore as 'HomeTeamScore',
				TeamScores.TotalScore as 'OpponentsTeamScore',
				Result as 'Summary',
				Teams.TeamLogo as 'OpponentTeamLogo',
				homeTeam.TeamLogo as 'HomeTeamTeamLogo',
				 (
					select top 1 count (case when HomeTeamWickets.HowOutId != '7' then 1 else null end) over()  as 'HomeTeamWickets'
					FROM Players
					inner join PlayerScores HomeTeamWickets on Players.PlayerId = HomeTeamWickets.PlayerId
					WHERE  Players.TeamId = homeTeam.TeamId					
				) as 'HomeTeamWickets',
				(
					select top 1 count (case when TeamWickets.HowOutId != '7' then 1 else null end) over()  as 'HomeTeamWickets'
					FROM Players
					inner join PlayerScores TeamWickets on Players.PlayerId = TeamWickets.PlayerId
					WHERE  Players.TeamId = Teams.TeamId					
				) as 'OppenentTeamWickets'
			
		
		FROM Matches		
		inner join Teams on  Teams.TeamId = Matches.OppponentTeamId
		inner join TeamScores on TeamScores.TeamId = Teams.TeamId
		inner join Teams homeTeam on  homeTeam.TeamId = Matches.HomeTeamId
		inner join TeamScores homeTeamScore on homeTeamScore.TeamId = homeTeam.TeamId
		order by Matches.MatchId Desc
	) AS LastMatch
end
go

exec [usp_HomeScreen] null
exec [usp_HomeScreen] 57
select * from AspNetUsers