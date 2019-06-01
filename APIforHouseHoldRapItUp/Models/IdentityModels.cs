using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using AspNet.Identity.MongoDB;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using MongoDB.Driver;
using APIforHouseHoldRapItUP.Properties;
using System.Configuration;
using System.ComponentModel.DataAnnotations;

namespace APIforHouseHoldRapItUP.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : AspNet.Identity.MongoDB.IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }

        internal Task<ClaimsIdentity> GenerateUserIdentityAsync(ApplicationUserManager userManager)
        {
            throw new NotImplementedException();
        }
        [DataType(DataType.Text)]
        public string Address { get; set; }
        [DataType(DataType.Text)]

        public string State { get; set; }
        [DataType(DataType.Text)]
        public string Country { get; set; }
    }


    public class ApplicationDbContext : IDisposable
    {
        private IMongoDatabase Database;
        public ApplicationDbContext()
           
        {
            
             var client = new MongoClient(ConfigurationManager.ConnectionStrings["MongoConn"].ConnectionString);
             Database = client.GetDatabase("TrainingBasket");
        }
        
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public IMongoCollection<ApplicationUser> Users => Database.GetCollection<ApplicationUser>("Users");
        public IMongoCollection<RegisterBindingModel> RegisteredUser => Database.GetCollection<RegisterBindingModel>("RegisteredUser");
        public void Dispose()
        {
           
        }
    }
}