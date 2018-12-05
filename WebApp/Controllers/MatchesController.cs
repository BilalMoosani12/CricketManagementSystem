﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CricketApp.Data;
using CricketApp.Domain;
using System.IO;
using WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using WebApp.ViewModels;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using WebApp.Helper;
using System.Data;
using Dapper;

namespace WebApp.Controllers
{

    public class MatchesController : Controller
    {
        private readonly CricketContext _context;
        private readonly UserManager<IdentityUser<int>> _userManager;
        private readonly IMapper _mapper;

        public MatchesController(
            CricketContext context,
            UserManager<IdentityUser<int>> userManager,
            IMapper mapper)
        {
            _context = context;
            _userManager = userManager;
            _mapper = mapper;
        }

        // GET: Matches
        [Route("Matches/Index")]
        public async Task<IActionResult> Index(int? teamId, int? matchTypeId,
                                               int? tournamentId, int? matchSeriesId,
                                                int? season, int? matchOvers, int? userId, int? page)
        {
            var users = await _userManager.GetUserAsync(HttpContext.User);

            ViewBag.Name = "Match";
            if (users != null)
                userId = users.Id;

            ViewBag.Overs = new SelectList(_context.Matches
                .Where(i => (userId.HasValue || i.UserId == userId))
                .Select(i => i.MatchOvers)
                .ToList().Distinct(), "MatchOvers");

            ViewBag.Season = new SelectList(_context.Matches
                .Where(i => (userId.HasValue || i.UserId == userId))
                .Select(i => i.Season)
                .ToList().Distinct(), "Season");

            ViewBag.MatchType = new SelectList(_context.MatchType, "MatchTypeId", "MatchTypeName");
            int pageSize = 20;

            ViewBag.Tournament = new SelectList(_context.Tournaments
                .Where(i => (!userId.HasValue || i.UserId == userId))
                .Select(i => new { i.TournamentId, i.TournamentName })
           , "TournamentId", "TournamentName");

            ViewBag.MatchSeries = new SelectList(_context.MatchSeries
                .Where(i => (!userId.HasValue || i.UserId == userId))
                .Select(i => new { i.MatchSeriesId, i.Name })
           , "MatchSeriesId", "Name");

            ViewBag.TeamId = new SelectList(_context.Teams
                .Where(i => (!userId.HasValue || i.clubAdmin.UserId == userId))
                .Select(i => new { i.TeamId, i.Team_Name })
                , "TeamId", "Team_Name");

            return View(await PaginatedList<ViewModels.Matchdto>.CreateAsync(
                _context.Matches
                .AsNoTracking()
               .Where(i => (!matchTypeId.HasValue || i.MatchTypeId == matchTypeId) &&
                           (!teamId.HasValue || i.HomeTeamId == teamId || i.OppponentTeamId == teamId) &&
                           (!tournamentId.HasValue || i.TournamentId == tournamentId) && (!season.HasValue || i.Season == season) &&
                           (!matchSeriesId.HasValue || i.MatchSeriesId == matchSeriesId) && (!matchOvers.HasValue || i.MatchOvers == matchOvers) &&
                           (!userId.HasValue || i.UserId == userId))
                .Select(i => new ViewModels.Matchdto
                {
                    MatchId = i.MatchId,
                    GroundName = i.GroundName,
                    DateOfMatch = i.DateOfMatch.HasValue ? i.DateOfMatch.Value.ToShortDateString() : "",
                    MatchOvers = i.MatchOvers,
                    Result = i.Result,
                    MatchType = i.MatchType.MatchTypeName,
                    //TournamentId = i.TournamentId,
                    MatchTypeId = i.MatchTypeId,
                    //Tournament = i.Tournament.TournamentName,
                    HomeTeam = i.HomeTeam.Team_Name,
                    OppponentTeam = i.OppponentTeam.Team_Name,
                    HomeTeamId = i.HomeTeamId,
                    OppponentTeamId = i.OppponentTeamId,
                    //MatchLogo = i.MatchLogo,
                    HasFilledHomeTeamData = i.PlayerScores.Any() && i.PlayerScores.Any(o => o.Player != null && o.Player.TeamId == i.HomeTeamId),
                    HasFilledOpponentTeamData = i.PlayerScores.Any() && i.PlayerScores.Any(o => o.Player != null && o.Player.TeamId == i.OppponentTeamId),
                    HasFilledTeamScoreData = i.TeamScores.Any() && i.TeamScores.Any(o => i.MatchId == i.MatchId)
                })
               .OrderByDescending(i => i.MatchId)
                                 , page ?? 1, pageSize));

        }

        // GET: MatchSummary
        public IActionResult Summary(int matchId, int homeTeamId, int oppTeamId, bool isApi)
        {
            ViewBag.Name = "Match Summary";
            var connection = _context.Database.GetDbConnection();
            var matchSummary = new Summary();

            var listOfPlayers = connection.Query<MatchSummaryPlayerList>(
               "[usp_MatchSummaryPlayerList]",
               new
               {
                   paramMatchId = matchId,
                   paramHomeTeamId = homeTeamId,
                   paramOpponentTeamId = oppTeamId

               },
               commandType: CommandType.StoredProcedure) ?? new List<MatchSummaryPlayerList>();

            var s = connection.Query<Summary2dto>(
                "[usp_Summary2]",
                new
                {
                    paramMatchId = matchId
                },
                commandType: CommandType.StoredProcedure) ?? new List<Summary2dto>();
            matchSummary.MatchSummaryPlayerList = listOfPlayers.ToList();
            matchSummary.Summary2dto = s.SingleOrDefault();
            if (isApi)
            {
                return Json(matchSummary);
            }
            return View(matchSummary);
        }

        // GET: Matches/Details/5
        public async Task<IActionResult> Details(int? matchId)
        {
            ViewBag.Name = "Match Detail";
            if (matchId == null)
            {
                return NotFound();
            }

            var match = await _context.Matches
                .Select(i => new Matchdto
                {
                    MatchId = i.MatchId,
                    HomeTeam = i.HomeTeam.Team_Name,
                    OppponentTeam = i.OppponentTeam.Team_Name,
                    DateOfMatch = i.DateOfMatch.HasValue ? i.DateOfMatch.Value.ToShortDateString() : "",
                    GroundName = i.GroundName,
                    Season = i.Season,
                    MatchType = i.MatchType.MatchTypeName,
                    Tournament = i.Tournament.TournamentName,
                    Series = i.MatchSeries.Name,
                    MatchOvers = i.MatchOvers,
                    Place = i.Place,
                    Result = i.Result,
                    PlayerOfTheMatch = i.Player.Player_Name


                })
                .SingleOrDefaultAsync(m => m.MatchId == matchId);
            if (match == null)
            {
                return NotFound();
            }

            return View(match);
        }

        //GET: Matches/Create

        [Authorize(Roles = "Club Admin,Administrator")]
        [Route("Matches/Create")]
        public async Task<IActionResult> Create(int? tournamentId, int? matchSeriesId)
        {
            ViewBag.Name = "Add Match";
            var users = await _userManager.GetUserAsync(HttpContext.User);
            ViewBag.TeamId = new SelectList(_context.Teams
                .Where(i => i.clubAdmin.UserId == users.Id)
                .Select(i => new { i.TeamId, i.Team_Name })
                , "TeamId", "Team_Name");

            ViewBag.PlayerOTM = new SelectList(_context.Players
                        .Where(i => i.Team.clubAdmin.UserId == users.Id)
                      .Select(i => new { i.PlayerId, i.Player_Name })
                      , "PlayerId", "Player_Name");

            if (tournamentId != null && matchSeriesId == null)
            {
                ViewBag.IsTournament = true;
                ViewBag.TournamentId = new SelectList(_context.Tournaments
                .AsNoTracking()
                .Where(i => i.TournamentId == tournamentId && i.UserId == users.Id)
                .Select(i => new { i.TournamentId, i.TournamentName })
                , "TournamentId", "TournamentName", tournamentId);
                ViewBag.MatchType = new SelectList(_context.MatchType
                    .Select(i => new { i.MatchTypeId, i.MatchTypeName })
                    , "MatchTypeId", "MatchTypeName", 2);
            }
            else if (matchSeriesId != null && tournamentId == null)
            {
                ViewBag.IsMatchSeries = true;
                ViewBag.MatchSeries = new SelectList(_context.MatchSeries
                    .Where(i => i.UserId == users.Id)
                    .Select(i => new { i.MatchSeriesId, i.Name })
                    , "MatchSeriesId", "Name", matchSeriesId);

                ViewBag.MatchType = new SelectList(_context.MatchType
                    .Select(i => new { i.MatchTypeId, i.MatchTypeName })
                    , "MatchTypeId", "MatchTypeName", 3);
            }
            else
            {
                ViewBag.MatchType = new SelectList(_context.MatchType
                    .Select(i => new { i.MatchTypeId, i.MatchTypeName })
                    , "MatchTypeId", "MatchTypeName");

                ViewBag.MatchSeries = new SelectList(_context.MatchSeries
                    .Where(i => i.UserId == users.Id)
                    .Select(i => new { i.MatchSeriesId, i.Name })
                    , "MatchSeriesId", "Name");

                ViewBag.TournamentId = new SelectList(_context.Tournaments
                    .Where(i => i.UserId == users.Id)
                     .Select(i => new { i.TournamentId, i.TournamentName })
                    , "TournamentId", "TournamentName");
            }

            return View();
        }


        [HttpPost]
        [Route("Matches/Create")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Club Admin,Administrator")]
        public async Task<IActionResult> Create(Matchdto match)
        {
            if (ModelState.IsValid)
            {

                var form = Request.Form;
                byte[] fileBytes = null;
                if (match.MatchImage != null)
                {
                    using (var stream = match.MatchImage.OpenReadStream())
                    {
                        fileBytes = ReadStream(stream);

                    }
                }
                var users = await _userManager.GetUserAsync(HttpContext.User);
                match.UserId = users.Id;
                match.MatchLogo = fileBytes ?? null;
                    _context.Matches.Add(_mapper.Map<Match>(match));
                    await _context.SaveChangesAsync();
                return Json(ResponseHelper.Success());
            }
            return Json(ResponseHelper.UnSuccess());
        }
        public static byte[] ReadStream(Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }

        // GET: Matches/Edit/5
        [Authorize(Roles = "Club Admin,Administrator")]
        public async Task<IActionResult> Edit(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }


            ViewBag.Name = "Edit Match";
            var users = await _userManager.GetUserAsync(HttpContext.User);
            ViewData["TeamId"] = new SelectList(_context.Teams
                .Select(i => new { i.TeamId, i.Team_Name })
                , "TeamId", "Team_Name");

            ViewBag.PlayerOTM = new SelectList(_context.Players
                     .Where(i => i.Team.clubAdmin.UserId == users.Id)
                   .Select(i => new { i.PlayerId, i.Player_Name })
                   , "PlayerId", "Player_Name");

            ViewBag.MatchType = new SelectList(_context.MatchType
                    .Select(i => new { i.MatchTypeId, i.MatchTypeName })
                    , "MatchTypeId", "MatchTypeName");

            ViewBag.MatchSeries = new SelectList(_context.MatchSeries
                .Where(i => i.UserId == users.Id)
                .Select(i => new { i.MatchSeriesId, i.Name })
                , "MatchSeriesId", "Name");

            ViewBag.TournamentId = new SelectList(_context.Tournaments
                .Where(i => i.UserId == users.Id)
                 .Select(i => new { i.TournamentId, i.TournamentName })
                , "TournamentId", "TournamentName");

            var match = await _context.Matches
                .AsNoTracking()
                .Select(i => new Matchdto
                {
                    MatchId = i.MatchId,
                    GroundName = i.GroundName,
                    MatchImage = i.MatchImage,
                    MatchLogo = i.MatchLogo,
                    MatchOvers = i.MatchOvers,
                    MatchSeriesId = i.MatchSeriesId,
                    MatchTypeId = i.MatchTypeId,
                    HomeTeamId = i.HomeTeamId,
                    OppponentTeamId = i.OppponentTeamId,
                    DateOfMatch = i.DateOfMatch.HasValue ? i.DateOfMatch.Value.ToShortDateString() : "",
                    Place = i.Place,
                    Result = i.Result,
                    Season = i.Season,
                    TournamentId = i.TournamentId,
                    PlayerOTM = i.PlayerOTM,


                })
                .SingleOrDefaultAsync(m => m.MatchId == id);
            if (match == null)
            {
                return NotFound();
            }
            return View(match);
        }

        // POST: Matches/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Club Admin,Administrator")]
        public async Task<IActionResult> Edit(Matchdto match)
        {
            if (ModelState.IsValid)
            {
                var form = Request.Form;
                byte[] fileBytes = null;
                if (match.MatchImage != null)
                {
                    using (var stream = match.MatchImage.OpenReadStream())
                    {
                        fileBytes = ReadStream(stream);

                    }
                }
                var users = await _userManager.GetUserAsync(HttpContext.User);
                match.UserId = users.Id;
                match.MatchLogo = fileBytes ?? null;
                _context.Update(_mapper.Map<Match>(match));
                await _context.SaveChangesAsync();

                return Json(ResponseHelper.UpdateSuccess());
            }
            return Json(ResponseHelper.UpdateUnSuccess());
        }



        // POST: Matches/Delete/5
        [Route("Matches/DeleteConfirmed")]
        [Authorize(Roles = "Club Admin,Administrator")]
        public async Task<IActionResult> DeleteConfirmed(int matchId)
        {
            var match = await _context.Matches
                .SingleOrDefaultAsync(m => m.MatchId == matchId);
            _context.Matches.Remove(match);
            await _context.SaveChangesAsync();
            return Ok();
        }

        public IActionResult MatchChartJson(int matchId)
        {
            ViewBag.MatchId = matchId;
            var graph = _context.FallOFWickets
                .Where(i => i.MatchId == matchId)
                .Select(i => new WebApp.ViewModels.FallOfWicketdto
                {
                    First = i.First,
                    Second = i.Second,
                    Third = i.Third,
                    Fourth = i.Fourth,
                    Fifth = i.Fifth,
                    Sixth = i.Sixth,
                    Seventh = i.Seventh,
                    Eight = i.Eight,
                    Ninth = i.Ninth,
                    Tenth = i.Tenth

                }).ToList();
            return Json(graph);

        }
        public IActionResult MatchChart(int matchId)
        {
            ViewBag.MatchId = matchId;
            ViewBag.MatchName = _context.FallOFWickets
                .Where(i => i.MatchId == matchId)
                .Select(i => i.Team.Team_Name).FirstOrDefault();
            return View();

        }

        private bool MatchExists(int id)
        {
            return _context.Matches.Any(e => e.MatchId == id);
        }
    }
}
