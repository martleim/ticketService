using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tickets.Model
{
    public class EventMetadata
    {
        [Display(Name = "Event Name")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Event Description")]
        [Required]
        public string Description { get; set; }
    }

    public class SessionMetadata
    {

        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Start Date Time")]
        [Required]
        public System.DateTime DateStart { get; set; }

        [Display(Name = "End Date Time")]
        [Required]
        public System.DateTime DateEnd { get; set; }

        [Display(Name = "Session Name")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Session Description")]
        [Required]
        public string Description { get; set; }

        [Range(0, 99999, ErrorMessage = "Please enter valid Price")]
        [Required]
        public double Price { get; set; }
        //[MustHaveOneElementAttribute(ErrorMessage = "At least a ticket is required")]
    }

    public class TicketSaleMetadata
    {
        [Required]
        public int TicketId { get; set; }
        [Required]
        public int SessionId { get; set; }

    }

    public class TicketMetadata
    {
        [Display(Name = "Ticket Name")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Ticket Price")]
        [Required]
        [Range(0, 99999, ErrorMessage = "Please enter valid Price")]
        public double Price { get; set; }
        [Display(Name = "Ticket Description")]
        [Required]
        public string Description { get; set; }

    }

    public class TransactionMetadata
    {
        [MustHaveOneElementAttribute(ErrorMessage = "At least a ticket is required")]
        public virtual ICollection<Ticket> Ticket { get; set; }
    }

    public class UserMetadata
    {
        
    }
}
