using eTicket.Models;
using eTickets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data.ViewModels
{
    public class NewEventDropdownsVM
    {
        public NewEventDropdownsVM()
        {
            Coordinators = new List<Coordinator>();
            Locations = new List<Location>();
            Speakers = new List<Speaker>();
        }

        public List<Coordinator> Coordinators { get; set; }
        public List<Location> Locations { get; set; }
        public List<Speaker> Speakers { get; set; }
    }
}
