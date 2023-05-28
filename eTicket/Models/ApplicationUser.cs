using eTickets.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eTicket.Models
{
    public class ApplicationUser:IdentityUser
    {
        [Display (Name = "Full Name")]
        public string FullName { get; set; }

     


    }
}
