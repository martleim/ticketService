using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tickets.DomainModel
{
    [MetadataType(typeof(EventMetadata))]
    public partial class Event
    {
    }

    [MetadataType(typeof(EventMetadata))]
    public partial class Session
    {
    }

    [MetadataType(typeof(TicketSaleMetadata))]
    public partial class TicketSale
    {
    }

    [MetadataType(typeof(TicketMetadata))]
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
