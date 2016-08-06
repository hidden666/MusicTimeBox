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
    
    public partial class User : IEntityBase
    {
        public User()
        {
            this.UserRole = new HashSet<UserRole>();
        }
    
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string HashedPassword { get; set; }
        public string Salt { get; set; }
        public Nullable<bool> IsLocked { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
    
        public virtual ICollection<UserRole> UserRole { get; set; }
    }
}