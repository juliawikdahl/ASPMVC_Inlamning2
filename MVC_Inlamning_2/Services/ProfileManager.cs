using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MVC_Inlamning_2.Models;
using MVC_Inlamning_2.Models.Data;

namespace MVC_Inlamning_2.Services
{
   
        public interface IProfileManager
        {
            Task<ProfileResult> CreateAsync(IdentityUser user, User User);
            Task<User> ReadAsync(string userId);

            Task<string> DisplayNameAsync(string userId);

        public string GetRolesById(int id);
        }

        public class ProfileManager : IProfileManager
        {
            private readonly AppDbContext _context;

            public ProfileManager(AppDbContext context)
            {
                _context = context;
            }

            public async Task<ProfileResult> CreateAsync(IdentityUser user, User User)
            {
                if (await _context.Users.AnyAsync(x => x.Id == user.Id))
                {
                    var userProfileEntity = new UserProfileEntity
                    {
                        FirstName = User.FirstName,
                        LastName = User.LastName,
                        Address = User.Address,
                        PostalCode = User.PostalCode,
                        City = User.City,
                        Country = User.Country,
                        UserId = user.Id
                    };

                    _context.UserProfiles.Add(userProfileEntity);
                    await _context.SaveChangesAsync();

                    return new ProfileResult { Succeeded = true };
                }

                return new ProfileResult { Succeeded = false };
            }

            public async Task<User> ReadAsync(string userId)
            {
                var user = new User();
                var profileEntity = await _context.UserProfiles.Include(x => x.User).FirstOrDefaultAsync(x => x.UserId == userId);
                if (profileEntity != null)
                {
                    user.FirstName = profileEntity.FirstName;
                    user.LastName = profileEntity.LastName;
                    user.Email = profileEntity.User.Email;
                    user.Address = profileEntity.Address;
                    user.PostalCode = profileEntity.PostalCode;
                    user.City = profileEntity.City;
                    user.Country = profileEntity.Country;
                    user.Id = profileEntity.Id;
                }

                return user;
            }

            public async Task<string> DisplayNameAsync(string userId)
            {
                var result = await ReadAsync(userId);
                return $"{result.FirstName} {result.LastName}";
            }

       
        public string GetRolesById(int id)
        {
            var userId = _context.UserProfiles.Where(p => p.Id == id).Select(p => p.UserId).FirstOrDefault();
            var userRoles = _context.UserRoles.Where(r => r.UserId == userId).Select(r => r.RoleId).FirstOrDefault();
            return _context.Roles.Where(r => r.Id == userRoles).Select(r => r.Name).FirstOrDefault();
        }
    }
}

        public class ProfileResult
        {
            public bool Succeeded { get; set; } = false;
        }
 


