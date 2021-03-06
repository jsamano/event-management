﻿using System;
using System.Collections.Generic;

namespace EventManagement.ApplicationCore.Models
{
    public class TicketType : BaseEntity
    {
        public Guid EventId { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public int? Quota { get; set; }

        public Event Event { get; set; }
        public List<Ticket> Tickets { get; set; }
    }
}