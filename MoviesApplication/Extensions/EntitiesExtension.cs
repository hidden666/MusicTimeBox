using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Infrastructure;
using MoviesApplication.Models;

namespace MoviesApplication.Extensions
{
    public static class EntitiesExtension
    {
        public static void UpdateCustomer(this Customer customer, CustomerViewModel customerVm)
        {
            customer.FirstName = customerVm.FirstName;
            customer.LastName = customerVm.LastName;
            customer.IdentityCard = customerVm.IdentityCard;
            customer.Mobile = customerVm.Mobile;
            customer.DateOfBirth = customerVm.DateOfBirth;
            customer.Email = customerVm.Email;
            customer.UniqueKey = (customerVm.UniqueKey == null || customerVm.UniqueKey == Guid.Empty)
                ? Guid.NewGuid() : customerVm.UniqueKey;
            customer.RegistrationDate = (customer.RegistrationDate == null || customer.RegistrationDate.Equals(DateTime.MinValue) ? DateTime.Now : customerVm.RegistrationDate);
        }
    }
}