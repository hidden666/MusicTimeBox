using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Authentication.ExtendedProtection;
using System.Text;
using System.Threading.Tasks;
using Data;
using Data.Interfaces;

namespace Infrastructure.Extensions
{
    public static class ExtensionMethods
    {
        public static User GetSingleUserByName(this IEntityBaseRepo<User> userRepository, string userName)
        {
            return userRepository.GetAll().FirstOrDefault(x => x.UserName.ToUpper().Equals(userName.ToUpper()));
        }
    }
}
