using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Data.Interfaces;
using Infrastructure;
using Infrastructure.Extensions;
using Membership.Interfaces;
using Data;

namespace Membership
{
    class MembershipService : IMembershipService
    {
        private readonly IEntityBaseRepo<User> userRepository;
        private readonly IEntityBaseRepo<Role> roleRepository;
        private readonly IEntityBaseRepo<UserRole> userroleRepository;
        private readonly IEncryptionService encryptionService;
        private readonly IUnitOfWork unitofWork;

        public MembershipService(
            IEntityBaseRepo<User> userRepository, 
            IEntityBaseRepo<Role> roleRepository, 
            IEntityBaseRepo<UserRole> userroleRepository,
            IEncryptionService encryptionService,
            IUnitOfWork unitofWork)
        {
            this.userRepository = userRepository;
            this.roleRepository = roleRepository;
            this.userroleRepository = userroleRepository;
            this.encryptionService = encryptionService;
            this.unitofWork = unitofWork;
        }

        private void AddUserToRole(User user, int roleID)
        {
            var singleRole = roleRepository.GetSingle(roleID);
            if (singleRole == null)
                throw new ApplicationException("Role does not exist");

            var userRole = new UserRole() { RoleId = roleID, UserId = user.Id };
            userroleRepository.Add(userRole);
        }

        private bool IsPasswordValid(User user, string password)
        {
            return string.Equals(this.encryptionService.EncryptPassword(password, user.Salt), user.HashedPassword);
        }

        private bool IsUserValid(User user, string password)
        {
            if (this.IsPasswordValid(user, password))
                return !user.IsLocked.Value;
            return false;
        }

        public MembershipContext ValidateUser(string username, string password)
        {
            var membershipContext = new MembershipContext();

            var user = userRepository.GetSingleUserByName(username);

            if (user != null && this.IsUserValid(user, password))
            {
                var userRoles = this.GetUserRoles(username);
                var identity = new GenericIdentity(user.UserName);

                membershipContext.User = user;
                membershipContext.Princial = new GenericPrincipal(identity, userRoles.Select(x => x.Name).ToArray());
            }

            return membershipContext;
        }

        public User CreateUser(string username, string email, string password, int[] roles)
        {
            var existingUser = this.userRepository.GetSingleUserByName(username);
            if(existingUser != null)
                throw new ApplicationException("User exisits in the database");

            var passwordSalt = this.encryptionService.CreateSalt();

            var user = new User()
            {
                UserName = username,
                Email = email,
                IsLocked = false,
                Salt = passwordSalt,
                HashedPassword = encryptionService.EncryptPassword(password, passwordSalt),
                DateCreated = DateTime.Now
            };

            this.userRepository.Add(user);

            unitofWork.Commit();

            foreach (var aRole in roles)
            {
                this.AddUserToRole(user, aRole);
            }

            unitofWork.Commit();

            return user;
        }

        public User GetUser(int userID)
        {
            return userRepository.GetSingle(userID);
        }

        public List<Role> GetUserRoles(string username)
        {
            var aUser = userRepository.GetSingleUserByName(username);

            if(aUser == null)
                throw new ApplicationException("User does not exist");

            List<Role> aLIst = new List<Role>();

            foreach (UserRole usrRole in aUser.UserRole)
            {
                aLIst.Add(usrRole.Role);
            }
            return aLIst.Distinct().ToList();
        }
    }
}
