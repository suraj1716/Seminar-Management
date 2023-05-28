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
    public class NewEventVM
    {
        public int Id { get; set; }

        [Display(Name = "Event name")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

   

        [Display(Name = "Event description")]
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Display(Name = "Price in $")]
        [Required(ErrorMessage = "Price is required")]
        public double Price { get; set; }

        [Display(Name = "Event poster URL")]
        [Required(ErrorMessage = "Event poster URL is required")]
        public string ImageURL { get; set; }

        [Display(Name = "Event start date")]
        [Required(ErrorMessage = "Start date is required")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Event Time")]
        [Required(ErrorMessage = "End Time is required")]
        public DateTime Time { get; set; }

       


        [Display(Name = "Select a category")]
        [Required(ErrorMessage = "Event category is required")]
        public EventCategory EventCategory { get; set; }

        //Relationships
        [Display(Name = "Select Speaker(s)")]
        [Required(ErrorMessage = "Event Speaker(s) is required")]
        public List<int> SpeakerIds { get; set; }

        [Display(Name = "Select a Location")]
        [Required(ErrorMessage = "Event Location is required")]
        public int LocationId { get; set; }

        [Display(Name = "Select a Coordinator")]
        [Required(ErrorMessage = "Event Coordinator is required")]
        public int CoordinatorId { get; set; }


     
    }   
}