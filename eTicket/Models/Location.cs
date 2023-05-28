using eTickets.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Models
{
    public class Location : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Street Number - Street Name - Suburb - State - Postcode")]
        [Required(ErrorMessage = "Address is Required")]
        public string Address { get; set; }
        

       

        //Relationships
        public List<Event> Events { get; set; }
    }
}