using eTicket.Models;
using eTickets.Data;
using eTickets.Data.Base;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Models
{
    public class Event : IEntityBase
    {


        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

     

        public string Description { get; set; }
        public double Price { get; set; }
        public string ImageURL { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime Time { get; set; }

        public EventCategory EventCategory { get; set; }

        //Relationships
        public List<Speaker_Event> Speakers_Events { get; set; }

        //Location
        public int LocationId { get; set; }

        [ForeignKey("LocationId")]
        public Location Location { get; set; }



        //Coordinator
        public int CoordinatorId { get; set; }
        [ForeignKey("CoordinatorId")]
        public Coordinator Coordinator { get; set; }




 

    }
}
