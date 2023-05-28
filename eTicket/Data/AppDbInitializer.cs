//using eTickets.Data.Static;
using eTicket.Models;
using eTickets.Data.Static;
using eTickets.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                //Location
                if (!context.Locations.Any())
                {
                    context.Locations.AddRange(new List<Location>()
                    {
                        new Location()
                        {
                            Address = "61 The Trongate, Granville, Nsw 2142"
                            
                        },
                        new Location()
                        {
                           Address = "61 The Trongate, Granville, Nsw 2142"
                        },
                        new Location()
                        {
                            Address = "62 The Trongate, Granville, Nsw 2142"
                        },
                        new Location()
                        {
                           Address = "63 The Trongate, Granville, Nsw 2142"
                        },
                        new Location()
                        {
                           Address = "64 The Trongate, Granville, Nsw 2142"
                        },
                    });
                    context.SaveChanges();
                }
                //Speakers
                if (!context.Speakers.Any())
                {
                    context.Speakers.AddRange(new List<Speaker>()
                    {
                        new Speaker()
                        {
                            FullName = "Speaker 1",
                            Bio = "This is the Bio of the first actor",
                            ProfilePictureURL = "http://dotnethow.net/images/actors/actor-1.jpeg"

                        },
                        new Speaker()
                        {
                            FullName = "Speaker 2",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureURL = "http://dotnethow.net/images/actors/actor-2.jpeg"
                        },
                        new Speaker()
                        {
                            FullName = "Speaker 3",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureURL = "http://dotnethow.net/images/actors/actor-3.jpeg"
                        },
                        new Speaker()
                        {
                            FullName = "Speaker 4",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureURL = "http://dotnethow.net/images/actors/actor-4.jpeg"
                        },
                        new Speaker()
                        {
                            FullName = "Speaker 5",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureURL = "http://dotnethow.net/images/actors/actor-5.jpeg"
                        }
                    });
                    context.SaveChanges();
                }  
                //Coordinators
                if (!context.Coordinators.Any())
                {
                    context.Coordinators.AddRange(new List<Coordinator>()
                    {
                        new Coordinator()
                        {
                            FullName = "Coordinator 1",
                            Bio = "This is the Bio of the first actor",
                            ProfilePictureURL = "http://dotnethow.net/images/producers/producer-1.jpeg"

                        },
                        new Coordinator()
                        {
                            FullName = "Coordinator 2",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureURL = "http://dotnethow.net/images/producers/producer-2.jpeg"
                        },
                        new Coordinator()
                        {
                            FullName = "Coordinator 3",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureURL = "http://dotnethow.net/images/producers/producer-3.jpeg"
                        },
                        new Coordinator()
                        {
                            FullName = "Coordinator 4",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureURL = "http://dotnethow.net/images/producers/producer-4.jpeg"
                        },
                        new Coordinator()
                        {
                            FullName = "Coordinator 5",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureURL = "http://dotnethow.net/images/producers/producer-5.jpeg"
                        }
                    });
                    context.SaveChanges();
                }
                //Events
                if (!context.Events.Any())
                {
                    context.Events.AddRange(new List<Event>()
                    {
                        new Event()
                        {
                            Name = "Line & Design Marketing",
                            Description = "This is the Life movie description",
                            Price = 39.50,
                            ImageURL = "http://dotnethow.net/images/movies/movie-3.jpeg",
                            StartDate = DateTime.Now.AddDays(-10),
                            Time = DateTime.Now.AddDays(10),
                            LocationId = 3,
                            CoordinatorId = 3,
                            EventCategory = EventCategory.Web_Marketing
                        },
                        new Event()
                        {
                            Name = "ZenBusiness",
                            Description = "This is the Shawshank Redemption description",
                            Price = 29.50,
                            ImageURL = "http://dotnethow.net/images/movies/movie-1.jpeg",
                            StartDate = DateTime.Now,
                            Time = DateTime.Now.AddDays(3),
                            LocationId = 1,
                            CoordinatorId = 1,
                            EventCategory = EventCategory.Real_Estate
                        },   
                        new Event()
                        {
                            Name = "ASX Investor Day",
                            Description = "This is the Ghost movie description",
                            Price = 39.50,
                            ImageURL = "http://dotnethow.net/images/movies/movie-4.jpeg",
                            StartDate = DateTime.Now,
                            Time = DateTime.Now.AddDays(7),
                            LocationId = 4,
                            CoordinatorId = 4,
                            EventCategory = EventCategory.investing
                        },
                        new Event()
                        {
                            Name = "Real Estate Expo",
                            Description = "This is the Race movie description",
                            Price = 39.50,
                            ImageURL = "http://dotnethow.net/images/movies/movie-6.jpeg",
                            StartDate = DateTime.Now.AddDays(-10),
                            Time = DateTime.Now.AddDays(-5),
                            LocationId = 1,
                            CoordinatorId = 2,
                            EventCategory = EventCategory. Real_Estate
                        },
                        new Event()
                        {
                            Name = "Adobe Summit",
                            Description = "This is the Scoob movie description",
                            Price = 39.50,
                            ImageURL = "http://dotnethow.net/images/movies/movie-7.jpeg",
                            StartDate = DateTime.Now.AddDays(-10),
                            Time = DateTime.Now.AddDays(-2),
                            LocationId = 1,
                            CoordinatorId = 3,
                            EventCategory = EventCategory. Web_Marketing
                        },
                        new Event()
                        {
                            Name = "Gartner Symposium",
                            Description = "This is the Cold Soles movie description",
                            Price = 39.50,
                            ImageURL = "http://dotnethow.net/images/movies/movie-8.jpeg",
                            StartDate = DateTime.Now.AddDays(3),
                            Time = DateTime.Now.AddDays(20),
                            LocationId = 1,
                            CoordinatorId = 5,
                            EventCategory = EventCategory.Personal_finance
                        }
                    });
                    context.SaveChanges();
                }
                //Speakers & Events
                if (!context.Speakers_Events.Any())
                {
                    context.Speakers_Events.AddRange(new List<Speaker_Event>()
                    {
                        new Speaker_Event()
                        {
                            SpeakerId = 1,
                            EventId = 1
                        },
                        new Speaker_Event()
                        {
                            SpeakerId = 3,
                            EventId = 1
                        },

                         new Speaker_Event()
                        {
                            SpeakerId = 1,
                            EventId = 2
                        },
                         new Speaker_Event()
                        {
                            SpeakerId = 4,
                            EventId = 2
                        },

                        new Speaker_Event()
                        {
                            SpeakerId = 1,
                            EventId = 3
                        },
                        new Speaker_Event()
                        {
                            SpeakerId = 2,
                            EventId = 3
                        },
                        new Speaker_Event()
                        {
                            SpeakerId = 5,
                            EventId = 3
                        },


                        new Speaker_Event()
                        {
                            SpeakerId = 2,
                            EventId = 4
                        },
                        new Speaker_Event()
                        {
                            SpeakerId = 3,
                            EventId = 4
                        },
                        new Speaker_Event()
                        {
                            SpeakerId = 4,
                            EventId = 4
                        },


                        new Speaker_Event()
                        {
                            SpeakerId = 2,
                            EventId = 5
                        },
                        new Speaker_Event()
                        {
                            SpeakerId = 3,
                            EventId = 5
                        },
                        new Speaker_Event()
                        {
                            SpeakerId = 4,
                            EventId = 5
                        },
                        new Speaker_Event()
                        {
                            SpeakerId = 5,
                            EventId = 5
                        },


                        new Speaker_Event()
                        {
                            SpeakerId = 3,
                            EventId = 6
                        },
                        new Speaker_Event()
                        {
                            SpeakerId = 4,
                            EventId = 6
                        },
                        new Speaker_Event()
                        {
                            SpeakerId = 5,
                            EventId = 6
                        },
                    });
                    context.SaveChanges();
                }
            }

        }

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {

                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                string adminUserEmail = "admin@etickets.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        FullName = "Admin User",
                        UserName = "admin-user",
                        Email = adminUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }


                string appUserEmail = "user@etickets.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        FullName = "Application User",
                        UserName = "app-user",
                        Email = appUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
    }
}