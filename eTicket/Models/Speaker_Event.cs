﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Models
{
    public class Speaker_Event
    {
        public int EventId { get; set; }
        public Event Event { get; set; }

        

        public int SpeakerId { get; set; }
        public Speaker Speaker { get; set; }
    }
}