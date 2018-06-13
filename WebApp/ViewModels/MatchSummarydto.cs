﻿using CricketApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.ViewModels
{
    public class MatchSummarydto
    {
        public int PlayerScoreId { get; set; }
        public int PlayerId { get; set; }
        public int Position { get; set; }
        public int MatchId { get; set; }
        public string Bowler { get; set; }
        public int? Bat_Runs { get; set; }
        public int? Bat_Balls { get; set; }
        public string HowOut { get; set; }
        public int? Ball_Runs { get; set; }
        public int? Overs { get; set; }
        public int? Wickets { get; set; }
        public int? Stump { get; set; }
        public int? Catches { get; set; }
        public int? Maiden { get; set; }
        public int? RunOut { get; set; }
        public int? Four { get; set; }
        public int? Six { get; set; }
        public bool IsPlayedInning { get; set; }
        public Player Player { get; set; }
        public Match Match { get; set; }
    }
}
