﻿using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.ViewModels;

namespace WebApp.IServices
{
    public interface IPlayers
    {
        Task<List<Playersdto>> GetAllPlayersList(int? teamId, int? playerRoleId, int? battingStyleId, int? bowlingStyleId, string name, int? userId, int? page);
        List<PlayersDropDowndto> GetAllPlayers();
        Task<PlayerPastRecorddto> GetPlayerPastRecordByPlayerId(int? playerId);
    }
}
