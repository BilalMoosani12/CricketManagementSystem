﻿Create PROCEDURE [usp_HomeTeamBatting]
@paramHomeTeamId AS INT,
@paramMatchId AS INT
AS
BEGIN 
SELECT TOP 3
         Players.Player_Name AS 'HomeTeamBatsman',
         PlayerScores.Bat_Runs As 'Runs',
		 PlayerScores.Bat_Balls As 'Balls'       
     FROM 
         PlayerScores
     INNER JOIN
         Players ON PlayerScores.PlayerId = Players.PlayerId
     INNER JOIN
         Teams ON Players.TeamId = Teams.TeamId
     INNER JOIN
         Matches ON PlayerScores.MatchId = Matches.MatchId
     WHERE 
         (Teams.TeamId = @paramHomeTeamId)
         AND (Matches.MatchId = @paramMatchId)
     GROUP BY 
         Players.Player_Name,
         PlayerScores.Bat_Runs,
		 PlayerScores.Bat_Balls
     ORDER BY
         MAX(Bat_Runs) DESC 

END
go