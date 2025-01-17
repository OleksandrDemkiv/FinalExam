﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalExam
{
    internal class VIPTicket : Ticket
    {
        public string AdditionalExtras { get; set; }
        public decimal AdditionalCost { get; set; }
        
        // override ToString method for displaying
        public override string ToString()
        {
            return $"{Name} - {(Price+AdditionalCost):c} {AdditionalExtras} [AVAILABLE - {AvailableTickets}]";
        }

        // main constructor with reference to base class
        public VIPTicket(string name, decimal price, int availableTickets, string additionalExtras, decimal additionalCost) : base(name, price, availableTickets)
        {
            AdditionalExtras = additionalExtras;
            AdditionalCost = additionalCost;
        }
    }

    internal class Ticket
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int AvailableTickets { get; set; }

        // override ToString method for displaying
        public override string ToString()
        {
            return $"{Name} - {Price:c} [AVAILABLE - {AvailableTickets}]";
        }

        // main constructor
        public Ticket(string name, decimal price, int availableTickets)
        {
            Name = name;
            Price = price;
            AvailableTickets = availableTickets;
        }
    }
}
