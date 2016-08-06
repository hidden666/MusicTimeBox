//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Data.Interfaces;

namespace Infrastructure
{
    using System;
    using System.Collections.Generic;

    public partial class Rental : IEntityBase 
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int StockId { get; set; }
        public Nullable<System.DateTime> RentalDate { get; set; }
        public Nullable<System.DateTime> ReturnedDate { get; set; }
        public Nullable<byte> Status { get; set; }
    
        public virtual Customer Customer { get; set; }
        public virtual Stock Stock { get; set; }
    }
}