using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tickets.Model
{
    [MetadataType(typeof(EventMetadata))]
    public partial class Event
    {
    }

    [MetadataType(typeof(SessionMetadata))]
    public partial class Session
    {
    }

    [MetadataType(typeof(TicketMetadata))]
    public partial class Ticket
    {
    }

    [MetadataType(typeof(TicketSaleMetadata))]
    public partial class TicketSale
    {
    }
    
    [MetadataType(typeof(TransactionMetadata))]
    public partial class Transaction
    {
    }

    [MetadataType(typeof(UserMetadata))]
    public partial class User
    {
    }
}
