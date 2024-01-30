using AmazonMVC.Constants;
using Microsoft.AspNetCore.Identity;

namespace AmazonMVC.Data
{
    public class DbSeeder
    {
        public static async Task SeedDefaultData(IServiceProvider service) {
            var userMgr = service.GetService<UserManager<IdentityUser>>();
            var roleMgr = service.GetService<RoleManager<IdentityRole>>();
            var dbContext = service.GetService<ApplicationDbContext>();

            //adding some roles to db
            await roleMgr.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
            await roleMgr.CreateAsync(new IdentityRole(Roles.User.ToString()));


            // Seed roles
            await SeedRoles(roleMgr);

            // Seed admin user
            await SeedAdminUser(userMgr);

            // Seed genres
            await SeedGenres(dbContext);

            // Seed products
            await SeedProducts(dbContext);

            //var admin = new IdentityUser
            //{
            //    UserName = "admin@gmail.com",
            //    Email = "admin@gmail.com",
            //    EmailConfirmed = true
            //};

            //var userInDb = await userMgr.FindByEmailAsync(admin.Email);
            //if (userInDb is null)
            //{
            //    await userMgr.CreateAsync(admin, "Admin@123");
            //    await userMgr.AddToRoleAsync(admin, Roles.Admin.ToString());
            //}
        }

        private static async Task SeedRoles(RoleManager<IdentityRole> roleMgr)
        {
            if (!await roleMgr.RoleExistsAsync(Roles.Admin.ToString()))
                await roleMgr.CreateAsync(new IdentityRole(Roles.Admin.ToString()));

            if (!await roleMgr.RoleExistsAsync(Roles.User.ToString()))
                await roleMgr.CreateAsync(new IdentityRole(Roles.User.ToString()));
        }

        private static async Task SeedAdminUser(UserManager<IdentityUser> userMgr)
        {
            var adminEmail = "admin@gmail.com";
            var admin = await userMgr.FindByEmailAsync(adminEmail);
            if (admin == null)
            {
                admin = new IdentityUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    EmailConfirmed = true
                };
                await userMgr.CreateAsync(admin, "Admin@123");
                await userMgr.AddToRoleAsync(admin, Roles.Admin.ToString());
            }
        }

        private static async Task SeedProducts(ApplicationDbContext dbContext)
        {
            // Seed products here
            
            dbContext.Products.AddRange(new List<Product>
            {
                new Product { Name = "Hamburger", Price = 10.99, Image = "https://t2.gstatic.com/licensed-image?q=tbn:ANd9GcRRto3IlY56MlAIOAvXHvPEVxBDVzG1uz1zULEBYdJ-I4Aa-xOyPEVvv7fmIjLnxaOz", GenreId = 1 },
                new Product { Name = "Screwdriver", Price = 20.99, Image = "https://upload.wikimedia.org/wikipedia/commons/1/1c/Screw_Driver_display.jpg", GenreId = 2 },
            });
            await dbContext.SaveChangesAsync();
            
        }

        private static async Task SeedGenres(ApplicationDbContext dbContext)
        {
            // Seed genres here
            dbContext.Genres.AddRange(new List<Genre>
            {
                new Genre { Name = "Food" },
                new Genre { Name = "Tools" },
            });
            await dbContext.SaveChangesAsync();
        }
    }
}
