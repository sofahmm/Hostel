//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Hostel.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class Ticket
    {
        public int ID { get; set; }
        public Nullable<System.DateTime> date { get; set; }
        public Nullable<int> IdRoom { get; set; }
        public Nullable<int> IdClient { get; set; }
        public Nullable<int> IDEmployee { get; set; }
    
        public virtual Client Client { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Room Room { get; set; }
    }
}
