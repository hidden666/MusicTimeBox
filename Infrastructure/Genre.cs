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

    public partial class Genre : IEntityBase
    {
        public Genre()
        {
            this.Movie = new HashSet<Movie>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<Movie> Movie { get; set; }
    }
}
