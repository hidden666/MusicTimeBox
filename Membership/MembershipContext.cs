using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Data;
using Infrastructure;

namespace Membership
{
    public class MembershipContext
    {
        public IPrincipal Princial { get; set; }
        public User User { get; set; }

        public bool IsValid()
        {
            return Princial != null;
        }
    }
}
