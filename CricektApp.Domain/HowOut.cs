﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CricketApp.Domain
{
    public class HowOut
    {
        public int HowOutId { get; set; }
        public string Name { get; set; }

    }
}
