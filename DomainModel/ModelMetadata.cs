using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Tickets.Model
{
    [DataContract(IsReference = true)]
    public class EventMetadata
    {
        [DataMember]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Display(Name = "Event Name")]
        [Required]
        [DataMember]
        public string Name { get; set; }

        [Display(Name = "Event Description")]
        [Required]
        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public virtual ICollection<Session> Session { get; set; }
        [DataMember]
        public virtual ICollection<Ticket> Ticket { get; set; }

    }
    [DataContract(IsReference = true)]
    public class SessionMetadata
    {

        [Display(Name = "Id")]
        [DataMember]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DataMember]
        public int EventId { get; set; }

        [Display(Name = "Start Date Time")]
        [Required]
        [DataMember]
        public System.DateTime DateStart { get; set; }

        [Display(Name = "End Date Time")]
        [Required]
        [DataMember]
        public System.DateTime DateEnd { get; set; }

        [Display(Name = "Session Name")]
        [Required]
        [DataMember]
        public string Name { get; set; }

        [Display(Name = "Session Description")]
        [Required]
        [DataMember]
        public string Description { get; set; }

        [Range(0, 99999, ErrorMessage = "Please enter valid Price")]
        [Required]
        [DataMember]
        public double Price { get; set; }

        [DataMember]
        public short SpacesAvailable { get; set; }

        [DataMember]
        public virtual ICollection<TicketSale> TicketSale { get; set; }

        [DataMember]
        public virtual ICollection<Ticket> Ticket { get; set; }
    }
    [DataContract(IsReference = true)]
    public class TicketSaleMetadata
    {
        [DataMember]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [DataMember]
        public int TicketId { get; set; }

        [DataMember]
        public int TransactionId { get; set; }

    }
    [DataContract(IsReference = true)]
    public class TicketMetadata
    {
        [DataMember]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Display(Name = "Ticket Name")]
        [Required]
        [DataMember]
        public string Name { get; set; }

        [Display(Name = "Ticket Price")]
        [Required]
        [DataMember]
        [Range(0, 99999, ErrorMessage = "Please enter valid Price")]
        public double Price { get; set; }
        [Display(Name = "Ticket Description")]
        [Required]
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public int EventId { get; set; }
        [DataMember]
        public int SessionId { get; set; }

    }
    [DataContract(IsReference = true)]
    public class TransactionMetadata
    {
        [DataMember]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [DataMember]
        public int UserId { get; set; }
        [DataMember]
        public System.DateTime TimeStamp { get; set; }
        [MustHaveOneElementAttribute(ErrorMessage = "At least a ticket is required")]
        [DataMember]
        public virtual ICollection<TicketSale> TicketSale { get; set; }
    }
    [DataContract(IsReference = true)]
    public class UserMetadata
    {
        
    }
}
